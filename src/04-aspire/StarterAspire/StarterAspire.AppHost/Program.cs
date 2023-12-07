var builder = DistributedApplication.CreateBuilder(args);

var apiservice = builder.AddProject<Projects.StarterAspire_ApiService>("apiservice");

builder.AddProject<Projects.StarterAspire_Web>("webfrontend")
    .WithReference(apiservice);

builder.Build().Run();
