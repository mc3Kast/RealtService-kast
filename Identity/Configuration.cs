using IdentityModel;
using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace RealtService.Identity
{
    public static class Configuration
    {
        /// <summary>
        /// List of services that alloed to use identity server
        /// </summary>
        public static IEnumerable<ApiScope> ApiScopes =>
            new List<ApiScope>
            {
                new ApiScope("RealServiceWebAPI", "Web API")
            };

        /// <summary>
        /// Scope for client to see user claims, id or profile
        /// </summary>
        public static IEnumerable<IdentityResource> IdentityResources =>
            new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile()
            };

        /// <summary>
        ///  
        /// </summary>
        public static IEnumerable<ApiResource> ApiResources =>
            new List<ApiResource>
            {
                new ApiResource("RealServiceWebAPI", "Web API", new string[] { JwtClaimTypes.Name} )
                {
                    Scopes = {"RealServiceWebAPI"}
                }
            };

        /// <summary>
        /// Clients that allowed to use identity server
        /// </summary>
        public static IEnumerable<Client> Clients =>
            new List<Client>
            {
                new Client
                {
                    ClientId = "realt-web-api",
                    ClientName = "RealtService Web",
                    AllowedGrantTypes = GrantTypes.Code,
                    RequireClientSecret = false,
                    RequirePkce = true,
                    RedirectUris =
                    {
                        "http://.../signin"
                    },
                    AllowedCorsOrigins =
                    {
                        "http://..."
                    },
                    PostLogoutRedirectUris =
                    {
                        "http://.../signout"
                    },
                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "RealServiceWebAPI"
                    },
                    AllowAccessTokensViaBrowser = true
                }
            };
    }
}
