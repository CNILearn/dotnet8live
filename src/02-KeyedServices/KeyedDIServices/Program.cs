using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddKeyedTransient<IGreetingService, FriendlyGreeting>("friendly");
builder.Services.AddKeyedTransient<IGreetingService, FormalGreeting>("formal");
builder.Services.AddTransient<HomeController>();
var app = builder.Build();

var greeting1 = app.Services.GetRequiredKeyedService<IGreetingService>("friendly");
Console.WriteLine(greeting1.Greet("Katharina"));

var controller = app.Services.GetRequiredService<HomeController>();
controller.Index("Stephanie");

public class HomeController([FromKeyedServices("formal")] IGreetingService greetingService)
{
    public void Index(string name)
    {
        var result = greetingService.Greet(name);
        Console.WriteLine(result);
    }
}

public interface IGreetingService
{
    string Greet(string name);
}

public class FriendlyGreeting : IGreetingService
{
    public string Greet(string name) => $"Hallo, {name}";
}

public class FormalGreeting : IGreetingService
{
    public string Greet(string name) => $"Guten Tag, {name}";
}
