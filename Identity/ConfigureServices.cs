using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using RealtService.Application.Common.JWT;
using System.Text;

namespace RealtService.Identity;

[Obsolete]
public static class ConfigureServices
{
    [Obsolete]
    public static IServiceCollection AddIdentityServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAuthorization();
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = configuration["JWT:Issuer"]!,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"]!)),
                    ValidateIssuerSigningKey = true,
                };
            });

        services.AddSingleton<IJwtTokenProvider, JwtTokenProvider>();
        services.AddSingleton<IJwtTokenValidationProvider, JwtTokenValidationProvider>(factory => new JwtTokenValidationProvider(configuration));

        return services;
    }
}
