using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace RealtService.Application.Common.JWT;
[Obsolete]
public interface IJwtTokenProvider
{
    string GetJwtToken
    (
        string? issuer,
        string? audience,
        DateTime? notBefore,
        IEnumerable<Claim> claims,
        DateTime? expires
    );
}
