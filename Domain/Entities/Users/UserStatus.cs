using RealtService.Domain.Entities.Base;

namespace RealtService.Domain.Entities.Users;

public class UserStatus : NamedEntity 
{
    public static readonly UserStatus ONLINE = new UserStatus()
    {
        Name = "OFFLINE",
    };

    public static readonly UserStatus OFFLINE = new UserStatus()
    { 
        Name = "ONLINE"
    };
}

