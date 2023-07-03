using Microsoft.AspNetCore.Identity;

namespace RealtService.Domain.Entities.Users;

/// <summary>
/// public virtual TKey Id { get; set; } = default!;
/// public virtual string? UserName { get; set; }
/// public virtual string? NormalizedUserName { get; set; }
/// public virtual string? Email { get; set; }
/// public virtual string? NormalizedEmail { get; set; }
/// public virtual bool EmailConfirmed { get; set; }
/// public virtual string? PasswordHash { get; set; }
/// public virtual string? SecurityStamp { get; set; }
/// public virtual string? ConcurrencyStamp { get; set; } = Guid.NewGuid().ToString();
/// public virtual string? PhoneNumber { get; set; }
/// public virtual bool PhoneNumberConfirmed { get; set; }
/// public virtual bool TwoFactorEnabled { get; set; }
/// public virtual DateTimeOffset? LockoutEnd { get; set; }
/// public virtual bool LockoutEnabled { get; set; }
/// public virtual int AccessFailedCount { get; set; }
/// </summary>

public abstract class User : IdentityUser<int>
{
    public virtual ICollection<UserClaim> Claims { get; }
    public virtual ICollection<UserContact> Contacts { get; }
    public virtual ICollection<UserLogin> Logins { get; }
    public virtual ICollection<UserToken> Tokens { get; }
    public virtual ICollection<UserBelongsToRole> BelongsToRoles { get; }
    public virtual ICollection<Offer> Offers { get; }

    public virtual int StatusId { get; set; }
    public virtual UserStatus Status { get; set; }
}
