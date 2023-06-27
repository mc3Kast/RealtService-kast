using Microsoft.EntityFrameworkCore;
using RealtService.Application.UnitOfWork;
using RealtService.Application.Users.Commands;
using RealtService.Domain.Entities.Users;
using RealtService.Persistence;
using RealtService.Persistence.UnitOfWork;
using RealtService.Persistence.UnitOfWork.Repositories;
using System.ComponentModel.DataAnnotations;

namespace RealtService.WebApi;

public class Program
{
    public static async Task Main(string[] args)
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

        RealtServiceDBContext context = new(dbOptions);
        UserRepository userRepository = new(context.Users);
        OfferRepository offerRepository = new(context.Offers);
        using IUnitOfWork uow = new UnitOfWork(context, offerRepository, userRepository);
        CreateAgencyCommand cad = new(
            Name: "123",
            Email: "vnavsb",
            HashPassword: "abcd",
            AgencyUniqueNumber: 1234,
            RegistrationDate: DateTime.Now,
            UserStatus: UserStatus.OFFLINE,
            UserRoles: new List<UserRole>() { UserRole.USER }
        );
        CreateAgencyCommandHandler cadCommandHandler = new(uow);
        await cadCommandHandler.Handle(cad, new CancellationTokenSource().Token);
        await app.RunAsync();
    }
}