var builder = DistributedApplication.CreateBuilder(args);

var gameApiService = builder.AddProject<Projects.Codebreaker_GameAPIs>("gameapi");

builder.AddProject<Projects.CodeBreaker_Bot>("bot")
    .WithReference(gameApiService);

builder.Build().Run();
