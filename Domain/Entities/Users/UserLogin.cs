using Microsoft.AspNetCore.Identity;

namespace RealtService.Domain.Entities.Users;

/// <summary>
///public virtual string LoginProvider { get; set; }
///public virtual string ProviderKey { get; set; }
///public virtual TKey UserId { get; set; }
/// </summary>
public class UserLogin: IdentityUserLogin<int>
{
    public User User { get; set; }
}
