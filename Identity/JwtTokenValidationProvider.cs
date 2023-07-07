using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Primitives;
using Microsoft.IdentityModel.Tokens;
using RealtService.Application.Common.JWT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealtService.Identity;
[Obsolete]
public class JwtTokenValidationProvider : IJwtTokenValidationProvider
{
    private readonly TokenValidationParameters _parameters;

    public JwtTokenValidationProvider(IConfiguration configuration)
    {
        _parameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = configuration["JWT:Issuer"]!,
            ValidateAudience = false,
            ValidateLifetime = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"]!)),
            ValidateIssuerSigningKey = true,
        };
    }

    public TokenValidationParameters Parameters => _parameters;
}
