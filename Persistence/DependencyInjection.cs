using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RealtService.Application.Interfaces;

namespace RealtService.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration["DbConnection"];
            services.AddDbContext<RealtServiceDbContext>(options =>
            {
                options.UseSqlite(connectionString);
            });
            services.AddScoped<IOfferDbContext>(provider =>
            
                provider.GetService<RealtServiceDbContext>()
            );
            return services;
        }
    }
}
