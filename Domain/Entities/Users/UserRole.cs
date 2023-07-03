using Microsoft.AspNetCore.Identity;
using RealtService.Domain.Entities.Base;

namespace RealtService.Domain.Entities.Users;

public class UserRole: IdentityRole<int>
{
    public ICollection<RoleClaim> Claims { get; set; }
    public ICollection<UserBelongsToRole> UserBelongsToRoles { get; set; }
}
