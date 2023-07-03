using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RealtService.Application.UnitOfWork;
using RealtService.Persistence.UnitOfWork;

namespace RealtService.Persistence;

public static class ConfigureServices
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        services.AddScoped<IUnitOfWork, UnitOfWork.UnitOfWork>();
        services.AddDbContext<RealtServiceDBContext>(options => options.UseSqlServer(
                configuration.GetConnectionString("LocalConnection"),
                optionsBuilder => optionsBuilder.MigrationsAssembly(typeof(RealtServiceDBContext).Assembly.FullName)
            ),
            contextLifetime: ServiceLifetime.Scoped,
            optionsLifetime: ServiceLifetime.Scoped);
        return services;
    }
}
