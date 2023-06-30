using System.Reflection;
using RealtService.Application.Common.Mappings;
using RealtService.Application.Offers.Queries.GetOfferDetails;
using RealtService.WebApi.Middleware;

namespace RealtService.WebApi;

public static class ConfigureServices
{
    public static IServiceCollection AddWebApiServices(this IServiceCollection services)
    {
        services.AddAutoMapper(conf => {
            conf.AddProfile(new AssemblyMappingProfile(Assembly.GetExecutingAssembly()));
            conf.AddProfile(new AssemblyMappingProfile(typeof(OfferDetailsVm).Assembly));
        });
        services.AddCors(options =>
        {
            options.AddPolicy("AllowAll", policy =>
            {
                policy.AllowAnyHeader();
                policy.AllowAnyMethod();
                policy.AllowAnyOrigin();
            });
        });
        services.AddControllersWithViews();
        services.AddSingleton<GlobalErrorHandler>();
        return services;
    }
}
