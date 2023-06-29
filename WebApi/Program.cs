using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RealtService.Application;
using RealtService.Application.Common.Mappings;
using RealtService.Application.Offers.Commands.CreateOffer;
using RealtService.Application.Offers.Queries.GetOfferDetails;
using RealtService.Application.Offers.Queries.GetOfferList;
using RealtService.Application.UnitOfWork;
using RealtService.Application.Users.Commands;
using RealtService.Domain.Entities.Users;
using RealtService.Persistence;
using RealtService.Persistence.UnitOfWork;
using RealtService.Persistence.UnitOfWork.Repositories;
using RealtService.WebApi.Middleware;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using static IdentityServer4.Models.IdentityResources;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace RealtService.WebApi;

public static class Program
{
    public static async Task Main(string[] args)
    {
        IConfiguration configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
        builder.Services
            .AddPersistanceServices(configuration)
            .AddApplicationServices()
            .AddWebApiServices();

        WebApplication app = builder.Build();
        app.UseMiddleware<GlobalErrorHandler>();
        app.UseRouting();
        app.UseHttpsRedirection();
        app.UseCors("AllowAll");
        app.MapControllers();
        await app.RunAsync();
    }
}