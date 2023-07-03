using Microsoft.AspNetCore.Identity;
using RealtService.Domain.Entities.Base;

namespace RealtService.Domain.Entities.Users;

public class UserRole: IdentityRole<int>
{
    public virtual ICollection<RoleClaim> Claims { get; set; }
    public virtual ICollection<UserBelongsToRole> UserBelongsToRoles { get; set; }
}
