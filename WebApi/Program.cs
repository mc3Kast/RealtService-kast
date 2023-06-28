using Microsoft.EntityFrameworkCore;
using RealtService.Application.Common.Mappings;
using RealtService.Application.UnitOfWork;
using RealtService.Application.Users.Commands;
using RealtService.Domain.Entities.Users;
using RealtService.Persistence;
using RealtService.Persistence.UnitOfWork;
using RealtService.Persistence.UnitOfWork.Repositories;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

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
        builder.Services.AddAutoMapper(conf => {
            conf.AddProfile(new AssemblyMappingProfile(Assembly.GetExecutingAssembly()));
            // нужно вставить вашу аналогию моего IOfferDbContext
            // conf.AddProfile(new AssemblyMappingProfile(typeof(IOfferDbContext).Assembly));
        });
        builder.Services.AddControllers();
        builder.Services.AddCors(options =>
        {
            options.AddPolicy("AllowAll", policy =>
            {
                policy.AllowAnyHeader();
                policy.AllowAnyMethod();
                policy.AllowAnyOrigin();
            });
        });
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
        app.UseRouting();
        app.UseHttpsRedirection();
        app.UseCors("AllowAll");
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });

        await app.RunAsync();
    }
}