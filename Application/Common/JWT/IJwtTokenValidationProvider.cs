using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealtService.Application.Common.JWT;
[Obsolete]
public interface IJwtTokenValidationProvider
{
    public TokenValidationParameters Parameters { get; }
}
