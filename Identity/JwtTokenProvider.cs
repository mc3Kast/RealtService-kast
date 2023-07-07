using Microsoft.IdentityModel.Tokens;
using RealtService.Application.Common.JWT;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace RealtService.Identity;
[Obsolete]
public class JwtTokenProvider : IJwtTokenProvider
{
    public string GetJwtToken
    (
        string? issuer,
        string? audience,
        DateTime? notBefore,
        IEnumerable<Claim> claims,
        DateTime? expires
    )
    {
        JwtSecurityToken jwt = new JwtSecurityToken
        (
            issuer: issuer,
            audience: audience,
            notBefore: notBefore,
            claims: claims,
            expires: expires
        );

        JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
        return handler.WriteToken(jwt);
    }
}
