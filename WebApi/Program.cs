using Microsoft.EntityFrameworkCore;
using RealtService.Persistence;

namespace RealtService.WebApi;

public class Program
{
    public static void Main(string[] args)
    {
        ConfigurationBuilder configurationBuilder = new ConfigurationBuilder();
        configurationBuilder.SetBasePath(Directory.GetCurrentDirectory());
        configurationBuilder.AddJsonFile("appsettings.json");
        IConfigurationRoot config = configurationBuilder.Build();
        string connectionString = config.GetConnectionString("DefaultConnection")!;

        DbContextOptionsBuilder optionsBuilder = new DbContextOptionsBuilder();
        DbContextOptions dbOptions = optionsBuilder
                        .UseSqlServer(connectionString)
                        .Options;


        var builder = WebApplication.CreateBuilder(args);
        var app = builder.Build();

        using RealtServiceDBContext context = new(dbOptions);
        app.MapGet("/", () => "Hello World!");
        app.Run();
    }
}