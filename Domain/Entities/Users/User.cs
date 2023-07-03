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
    public ICollection<UserClaim> Claims { get; }
    public ICollection<UserContact> Contacts { get; }
    public  ICollection<UserLogin> Logins { get; }
    public ICollection<UserToken> Tokens { get; }
    public ICollection<UserBelongsToRole> BelongsToRoles { get; }
    public ICollection<Offer> Offers { get; }

    public int StatusId { get; set; }
    public UserStatus Status { get; set; }
}
