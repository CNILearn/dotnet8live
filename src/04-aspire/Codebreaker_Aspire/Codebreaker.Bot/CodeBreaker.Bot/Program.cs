using System.Runtime.CompilerServices;
using CodeBreaker.Bot.Endpoints;

[assembly: InternalsVisibleTo("MMBot.Tests")]

var builder = WebApplication.CreateBuilder(args);

// Aspire defaults
builder.AddServiceDefaults();

// Swagger & EndpointDocumentation
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// HttpClient & Application Services
builder.Services.AddHttpClient<GamesClient>(options =>
{
    string codebreakeruri = builder.Configuration["ApiBase"]
        ?? throw new InvalidOperationException("ApiBase configuration not available");

    var apiUri = new Uri(codebreakeruri);

    options.BaseAddress = apiUri;
});
builder.Services.AddScoped<CodeBreakerTimer>();
builder.Services.AddScoped<CodeBreakerGameRunner>();

var app = builder.Build();

// Aspire
app.MapDefaultEndpoints();

// Swagger
app.UseSwagger();
app.UseSwaggerUI();

// Bot
app.MapBotEndpoints();

app.Run();
