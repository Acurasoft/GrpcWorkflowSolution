using Grpc.Net.Client;
using GrpcWorkflow.Shared;

public class StreamingClient
{
    public static async Task RunAsync()
    {
        using var channel = GrpcChannel.ForAddress("https://localhost:5001");
        var client = new Streamer.StreamerClient(channel);

        using var call = client.StreamNumbers(new StreamRequest { Count = 5 });

        await foreach (var message in call.ResponseStream.ReadAllAsync())
        {
            Console.WriteLine($"[Streaming] Received: {message.Number}");
        }
    }
}
