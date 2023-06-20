namespace RealtService.WebApi;

public class Program
{
    public int X { get; set; }
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var app = builder.Build();

        app.MapGet("/", () => "Hello World!");
        app.Run();
    }
}