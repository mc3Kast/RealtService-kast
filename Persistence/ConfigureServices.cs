using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RealtService.Application.UnitOfWork;
using RealtService.Domain.Entities.Users;
using RealtService.Persistence.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace RealtService.Persistence;

public static class ConfigureServices
{
    public static IServiceCollection AddPersistanceServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton(typeof(IRepository<>), typeof(Repository<>));
        services.AddSingleton<IUnitOfWork, UnitOfWork.UnitOfWork>();
        services.AddDbContext<RealtServiceDBContext>(options => options.UseSqlServer(
                configuration.GetConnectionString("LocalConnection"),
                optionsBuilder => optionsBuilder.MigrationsAssembly(typeof(RealtServiceDBContext).Assembly.FullName)
            ),
            contextLifetime: ServiceLifetime.Singleton,
            optionsLifetime: ServiceLifetime.Singleton);
        return services;
    }
}
