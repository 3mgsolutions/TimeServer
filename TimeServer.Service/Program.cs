using TimeServer.Service.Services;
using Microsoft.Extensions.Hosting.WindowsServices;



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

builder.Services.AddGrpc();

// Add reflection services
builder.Services.AddGrpcReflection();

var app = builder.Build();

app.MapGrpcService<GreeterService>();
app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");


// Map reflection endpoint
app.MapGrpcReflectionService();

app.Run();
