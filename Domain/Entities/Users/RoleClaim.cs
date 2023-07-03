using Microsoft.AspNetCore.Identity;

namespace RealtService.Domain.Entities.Users;

public class RoleClaim: IdentityRoleClaim<int>
{
    public virtual UserRole Role { get; set; }
}
