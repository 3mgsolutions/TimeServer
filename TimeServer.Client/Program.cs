// See https://aka.ms/new-console-template for more information
using Grpc.Net.Client;
using Microsoft.Extensions.Logging;
using System.Security.Cryptography.X509Certificates;
using TimeServer.Service;
using static System.Net.WebRequestMethods;

Console.WriteLine("Press any key to send a request");
Console.ReadKey();

try
{
    var loggerFactory = LoggerFactory.Create(logging =>
    {
        logging.AddConsole();
        logging.SetMinimumLevel(LogLevel.Debug);
    });

    string certificateFilePath = Path.GetDirectoryName(System.AppDomain.CurrentDomain.BaseDirectory);
    var certificate = new X509Certificate2(certificateFilePath += "\\Certificate\\cert.pfx", "password123");
    var handler = new HttpClientHandler();
    handler.ClientCertificates.Add(certificate);

    handler.ClientCertificateOptions = ClientCertificateOption.Manual;
    handler.ServerCertificateCustomValidationCallback =
        (httpRequestMessage, cert, cetChain, policyErrors) =>
        {
            return true;
        };

    var httpClient = new HttpClient(handler);

    using var channel = GrpcChannel.ForAddress("https://localhost:7001", new GrpcChannelOptions { HttpClient = httpClient, LoggerFactory = loggerFactory,
    });

    var client = new Greeter.GreeterClient(channel);

    // Service call
    var helloResponse = client.SayHello(new HelloRequest { Name = "" });
    Console.WriteLine($"Response from GreeterService: {helloResponse.Message}");
}
catch (Exception ex)
{
}
Console.WriteLine("Press any key ...");
Console.ReadKey();
