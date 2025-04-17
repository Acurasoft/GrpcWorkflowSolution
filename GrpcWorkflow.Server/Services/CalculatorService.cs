using Grpc.Core;
using GrpcWorkflow.Shared;

namespace GrpcWorkflow.Server.Services;

public class CalculatorService : Calculator.CalculatorBase
{
    public override Task<AddReply> Add(AddRequest request, ServerCallContext context)
    {
        int result = request.A + request.B;
        Console.WriteLine($"[gRPC] Add({request.A}, {request.B}) = {result}");
        return Task.FromResult(new AddReply { Result = result });
    }
}
