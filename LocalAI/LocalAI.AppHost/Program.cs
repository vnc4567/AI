var builder = DistributedApplication.CreateBuilder(args);

var ollama = builder.AddOllama("ollama")
                    .WithContainerRuntimeArgs("--gpus=all")
                    .WithDataVolume()
                    .WithOpenWebUI();

IResourceBuilder<OllamaModelResource> phi4 = ollama.AddModel("phi4", "phi4");

builder.AddProject<Projects.LocalAI_Web>("webfrontend")
       .WithExternalHttpEndpoints()
       .WithReference(phi4)
       .WaitFor(phi4);

builder.Build().Run();
