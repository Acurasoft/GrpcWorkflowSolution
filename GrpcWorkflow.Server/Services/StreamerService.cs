using Grpc.Core;
using GrpcWorkflow.Shared;

namespace GrpcWorkflow.Server.Services;

public class StreamerService : Streamer.StreamerBase
{
    public override async Task StreamNumbers(StreamRequest request, IServerStreamWriter<StreamReply> responseStream, ServerCallContext context)
    {
        for (int i = 1; i <= request.Count; i++)
        {
            await responseStream.WriteAsync(new StreamReply { Number = i });
            await Task.Delay(500); // simulate delay
        }
    }
}
