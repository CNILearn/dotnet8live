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
builder.Services.AddHttpClient<GamesClient>(client =>
{
    client.BaseAddress = new("http://gameapi");
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
