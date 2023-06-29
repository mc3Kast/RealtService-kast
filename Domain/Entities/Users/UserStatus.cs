using RealtService.Domain.Entities.Base;

namespace RealtService.Domain.Entities.Users;

public class UserStatus : NamedEntity 
{
    public static readonly UserStatus ONLINE = new UserStatus()
    {
        Id = 1,
        Name = "OFFLINE",
    };

    public static readonly UserStatus OFFLINE = new UserStatus()
    { 
        Id = 2,
        Name = "ONLINE"
    };
}

