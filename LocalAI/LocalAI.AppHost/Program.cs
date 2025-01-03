var builder = DistributedApplication.CreateBuilder(args);

var ollama = builder.AddOllama("ollama")
                    .WithDataVolume()
                    .WithOpenWebUI();

var phi3 = ollama.AddModel("phi3", "phi3");

builder.AddProject<Projects.LocalAI_Web>("webfrontend")
       .WithExternalHttpEndpoints()
       .WithReference(phi3)
       .WaitFor(phi3);

builder.Build().Run();
