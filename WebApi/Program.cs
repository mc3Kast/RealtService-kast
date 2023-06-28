using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RealtService.Application.Common.Mappings;
using RealtService.Application.Offers.Commands.CreateOffer;
using RealtService.Application.Offers.Queries.GetOfferList;
using RealtService.Application.UnitOfWork;
using RealtService.Application.Users.Commands;
using RealtService.Domain.Entities.Users;
using RealtService.Persistence;
using RealtService.Persistence.UnitOfWork;
using RealtService.Persistence.UnitOfWork.Repositories;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using static IdentityServer4.Models.IdentityResources;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace RealtService.WebApi;

public class Program
{
    public static async Task Main(string[] args)
    {
        ConfigurationBuilder configurationBuilder = new ConfigurationBuilder();
        configurationBuilder.SetBasePath(Directory.GetCurrentDirectory());
        configurationBuilder.AddJsonFile("appsettings.json");
        IConfigurationRoot config = configurationBuilder.Build();
        //string connectionString = config.GetConnectionString("DefaultConnection")!;
        string connectionString = "Server=(localdb)\\MSSQLLocalDB;Initial Catalog=RealtServiceTest;Trusted_Connection=True;";

        DbContextOptionsBuilder optionsBuilder = new DbContextOptionsBuilder();
        DbContextOptions dbOptions = optionsBuilder
                       .UseSqlServer(connectionString)
                       .Options;


        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddAutoMapper(conf => {
            conf.AddProfile(new AssemblyMappingProfile(Assembly.GetExecutingAssembly()));
            conf.AddProfile(new AssemblyMappingProfile(typeof(RealtServiceDBContext).Assembly));
        });

        builder.Services.AddDbContext<RealtServiceDBContext>(options => options.UseSqlServer(connectionString));
        builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
        builder.Services.AddScoped<OfferRepository, OfferRepository>();
        builder.Services.AddScoped<UserRepository, UserRepository>();

        //builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<GetOfferListQueryHandler>());

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
        UserRepository userRepository = new(context);
        OfferRepository offerRepository = new(context);
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
        CreateOfferCommand coc = new(
            Title: "222",
            Description: "asd",
            Address: "asd"
        );
        CreateAgencyCommandHandler cadCommandHandler = new(uow);
        CreateOfferCommandHandler cocCommandHandler = new(uow);
        await cadCommandHandler.Handle(cad, new CancellationTokenSource().Token);
        await cocCommandHandler.Handle(coc, new CancellationTokenSource().Token);
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