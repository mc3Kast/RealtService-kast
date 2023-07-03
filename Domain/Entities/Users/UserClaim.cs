using Microsoft.AspNetCore.Identity;
using RealtService.Domain.Entities.Base;

namespace RealtService.Domain.Entities.Users;

/// <summary>
/// public virtual int Id { get; set; }
/// public virtual TKey UserId { get; set; }
/// public virtual string ClaimType { get; set; }
/// public virtual string ClaimValue { get; set; }
/// </summary>
public class UserClaim: IdentityUserClaim<int>
{
    public virtual User User { get; set; }
}
