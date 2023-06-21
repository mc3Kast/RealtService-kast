using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealtService.Persistence;

public static class ConfigureServices
{
    public static IServiceCollection AddPersistanceServices(this IServiceCollection services, IConfiguration configuration)
    {
        /*var connectionString = configuration["DbConnection"];
        services.AddDbContext<RealtServiceDbContext>(options =>
        {
            //options.UseSqlServer(connectionString);
        });
        services.AddScoped<IOfferDbContext>(provider =>
            provider.GetService<RealtServiceDbContext>());
        return services;*/
        return services;
    }
}
