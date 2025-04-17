FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["GrpcWorkflow.Server/GrpcWorkflow.Server.csproj", "GrpcWorkflow.Server/"]
RUN dotnet restore "GrpcWorkflow.Server/GrpcWorkflow.Server.csproj"
COPY . .
WORKDIR "/src/GrpcWorkflow.Server"
RUN dotnet build "GrpcWorkflow.Server.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "GrpcWorkflow.Server.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GrpcWorkflow.Server.dll"]
