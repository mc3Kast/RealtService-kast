using Microsoft.Extensions.DependencyInjection;
using RealtService.Application.Common.JWT;
using RealtService.Application.Common.Mappings;

namespace RealtService.Application
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<GeneralProfile>());
            return services;
        }
    }
}
