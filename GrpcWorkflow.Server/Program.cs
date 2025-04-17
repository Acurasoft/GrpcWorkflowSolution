var builder = WebApplication.CreateBuilder(args);
builder.Services.AddGrpc();

var app = builder.Build();
app.MapGrpcService<GrpcWorkflow.Server.Services.CalculatorService>();
app.MapGet("/", () => "Use a gRPC client.");

app.Run();
