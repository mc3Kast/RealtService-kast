using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Configuration;
using RealtService.Domain.Entities.Users;
using RealtService.Persistence.Helpers;

namespace RealtService.Persistence;

public class RealtServiceDbContextInitializer
{
    private RoleManager<UserRole> _roleManager;
    private UserManager<User> _userManager;
    private RealtServiceDBContext _dbContext;

    public RealtServiceDbContextInitializer
    (
        RoleManager<UserRole> roleManager,
        UserManager<User> userManager,
        RealtServiceDBContext dbContext
    )
    {
        _roleManager = roleManager;
        _userManager = userManager;
        _dbContext = dbContext;
    }

    public async Task InitializeDatabaseAsync(IConfiguration configuration)
    {
        _dbContext.Database.EnsureDeleted();
        _dbContext.Database.EnsureCreated();

        if (!_dbContext.Database.GetService<IRelationalDatabaseCreator>().Exists())
        {
            return;
        }

        IEnumerable<string> roles = new string[2] { "Customer", "Admin" };
        foreach (string role in roles)
        {
            IdentityResult roleResult = await _roleManager.CreateAsync(new UserRole(role));
            if (!roleResult.Succeeded)
            {
                throw roleResult.Errors.AsAggregateException();
            }
        }

        User defaultAdmin = new Agency
        {
            UserName = configuration["Initializer:DefaultAdmin:UserName"]!,
            AgencyUniqueNumber = -1,
            Email = configuration["Initializer:DefaultAdmin:Email"]!
        };

        string password = configuration["Initializer:DefaultAdmin:Password"]!;
        IdentityResult userResult = await _userManager.CreateAsync(defaultAdmin, password);
        if (!userResult.Succeeded)
        {
            throw userResult.Errors.AsAggregateException();
        }

        IdentityResult attachResult = await _userManager.AddToRolesAsync(defaultAdmin, roles);
        if (!userResult.Succeeded)
        {
            throw attachResult.Errors.AsAggregateException();
        }
    }
}
