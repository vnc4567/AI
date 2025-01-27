using LocalAI.Web;
using LocalAI.Web.Components;
using Microsoft.SemanticKernel;
using System.Text.RegularExpressions;

var builder = WebApplication.CreateBuilder(args);

// Add service defaults & Aspire client integrations.
builder.AddServiceDefaults();

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddOutputCache();

builder.Services.AddHttpClient<WeatherApiClient>(client =>
    {
        // This URL uses "https+http://" to indicate HTTPS is preferred over HTTP.
        // Learn more about service discovery scheme resolution at https://aka.ms/dotnet/sdschemes.
        client.BaseAddress = new("https+http://apiservice");
    });

var kernelBuilder = Kernel.CreateBuilder();
#pragma warning disable SKEXP0070
Regex regex = new Regex("Endpoint=(?<url>.*);");
string connectionString = Environment.GetEnvironmentVariable("ConnectionStrings__phi4");

Match match = regex.Match(connectionString);

Console.WriteLine(match.Groups["url"].Value);
kernelBuilder.AddOllamaChatCompletion("phi4", new HttpClient()
{
    BaseAddress = new Uri(match.Groups["url"].Value),
    Timeout = TimeSpan.FromMinutes(10),
});
#pragma warning restore SKEXP0070
Kernel kernel = kernelBuilder.Build();

builder.Services.AddTransient(_ => kernel);

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseAntiforgery();

app.UseOutputCache();

app.UseStaticFiles();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.MapDefaultEndpoints();

app.Run();
