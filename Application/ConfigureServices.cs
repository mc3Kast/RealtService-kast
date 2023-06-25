using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using MediatR;
using System.Net.NetworkInformation;
using RealtService.Application.Users.Commands;

namespace RealtService.Application
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CreateAgencyCommand).Assembly));
            return services;
        }
    }
}
