using TimeServer.Service.Services;
using Microsoft.Extensions.Hosting.WindowsServices;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using System.Security.Cryptography.X509Certificates;
using Humanizer;
using System.Runtime.ConstrainedExecution;
using Microsoft.Extensions.Options;
using System.Net;
using Microsoft.AspNetCore.Authentication.Certificate;


// Use WebApplicationOptions to set the ContentRootPath
var builder = WebApplication.CreateBuilder(new WebApplicationOptions
{
    Args = args,
    ContentRootPath = WindowsServiceHelpers.IsWindowsService()
        ? AppContext.BaseDirectory
        : default
});


// Set WindowsServiceLifetime
builder.Host.UseWindowsService();
builder.WebHost.ConfigureKestrel(kestrel =>
{
    kestrel.Listen(IPAddress.Loopback, 7000);
    kestrel.Listen(IPAddress.Loopback, 7001, configure => configure.UseHttps(https =>
    {
        string certificateFilePath = Path.GetDirectoryName(System.AppDomain.CurrentDomain.BaseDirectory);
        https.ServerCertificate = new X509Certificate2(certificateFilePath += "\\Certificate\\cert.pfx", "password123");
        //https.ClientCertificateMode = Microsoft.AspNetCore.Server.Kestrel.Https.ClientCertificateMode.RequireCertificate;
    }));
});

builder.Services.AddAuthentication(CertificateAuthenticationDefaults.AuthenticationScheme)
    .AddCertificate();

builder.Services.AddGrpc();
builder.Services.AddGrpcReflection();

builder.Services.AddDbContext<TimeServerDbContext>();
                //(x => x.UseSqlite(builder.Configuration.GetConnectionString("TimeServerDatabase")));

var app = builder.Build();

app.UseAuthentication();

app.MapGrpcService<GreeterService>();
app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

// Map reflection endpoint
app.MapGrpcReflectionService();

app.Run();
