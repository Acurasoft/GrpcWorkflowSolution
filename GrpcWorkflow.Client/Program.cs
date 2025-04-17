using System;
using System.Threading.Tasks;
using CoreWf;
using Grpc.Net.Client;
using GrpcWorkflow.Shared;

class Program
{
    static async Task Main(string[] args)
    {
        Console.WriteLine("Starting gRPC Client...");

        using var channel = GrpcChannel.ForAddress("https://localhost:5001");
        var client = new Calculator.CalculatorClient(channel);
        var response = await client.AddAsync(new AddRequest { A = 10, B = 20 });

        Console.WriteLine($"[gRPC] Response: {response.Result}");

        // Run CoreWF workflow
        var workflow = AddWorkflow.Create();
        WorkflowInvoker.Invoke(workflow);
    }
}
