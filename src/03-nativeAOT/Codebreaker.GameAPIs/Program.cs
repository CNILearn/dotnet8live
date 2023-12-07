using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;

[assembly: InternalsVisibleTo("Codbreaker.APIs.Tests")]

var builder = WebApplication.CreateSlimBuilder(args);

builder.Services.ConfigureHttpJsonOptions(options =>
{
    options.SerializerOptions.TypeInfoResolverChain.Insert(0, CodebreakerJsonSerializerContext.Default);
});

// Application Services

builder.Services.AddSingleton<IGamesRepository, GamesMemoryRepository>();
builder.Services.AddScoped<IGamesService, GamesService>();

var app = builder.Build();

app.MapGameEndpoints();

app.Run();

[JsonSerializable(typeof(CreateGameRequest))]
[JsonSerializable(typeof(CreateGameResponse))]
[JsonSerializable(typeof(CreateGameRequest))]
[JsonSerializable(typeof(UpdateGameRequest))]
[JsonSerializable(typeof(UpdateGameResponse))]
[JsonSerializable(typeof(Game))]
[JsonSerializable(typeof(IEnumerable<Game>))]
internal partial class CodebreakerJsonSerializerContext : JsonSerializerContext { }