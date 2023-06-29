using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using MediatR;
using System.Net.NetworkInformation;
using RealtService.Application.Users.Commands;
using RealtService.Application.UnitOfWork;

namespace RealtService.Application
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<CreateAgencyCommand>());
            return services;
        }
    }
}
