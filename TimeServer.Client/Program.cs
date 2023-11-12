// See https://aka.ms/new-console-template for more information
using Grpc.Net.Client;
using Microsoft.Extensions.Logging;
using TimeServer.Service;

Console.WriteLine("Press any key to send a request");
Console.ReadKey();

try
{
    var loggerFactory = LoggerFactory.Create(logging =>
    {
        logging.AddConsole();
        logging.SetMinimumLevel(LogLevel.Debug);
    });

    using var channel = GrpcChannel.ForAddress("https://localhost:7235", new GrpcChannelOptions { LoggerFactory = loggerFactory });

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
