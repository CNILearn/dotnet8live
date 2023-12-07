using System.Runtime.CompilerServices;

using Microsoft.OpenApi.Models;

[assembly: InternalsVisibleTo("Codbreaker.APIs.Tests")]

var builder = WebApplication.CreateBuilder(args);

// Aspire defaults
builder.AddServiceDefaults();

// Swagger/EndpointDocumentation
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v3", new OpenApiInfo
    {
        Version = "v3",
        Title = "Codebreaker Games API",
        Description = "An ASP.NET Core minimal API to play Codebreaker games",
        TermsOfService = new Uri("https://www.cninnovation.com/terms"),
        Contact = new OpenApiContact
        {
            Name = "Christian Nagel",
            Url = new Uri("https://csharp.christiannagel.com")
        },
        License = new OpenApiLicense
        {
            Name="License API Usage",
            Url= new Uri("https://www.cninnovation.com/apiusage")
        }
    });
});

builder.Services.AddMetrics();

builder.Services.AddSingleton<GamesMetrics>();

// Application Services

builder.Services.AddSingleton<IGamesRepository, GamesMemoryRepository>();
builder.Services.AddScoped<IGamesService, GamesService>();

var app = builder.Build();

// Aspire
app.MapDefaultEndpoints();

// Swagger
app.UseSwagger();
app.UseSwaggerUI(options =>
{
    // options.InjectStylesheet("/swagger-ui/swaggerstyle.css");
    options.SwaggerEndpoint("/swagger/v3/swagger.json", "v3");
});

// GameAPI
app.MapGameEndpoints();

app.Run();
