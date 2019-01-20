using System.Collections.Generic;
using IdentityServer4.Models;

namespace UniversityManagementSystem.DataSources.IdentityServer
{
    public static class Config
    {
        public static IEnumerable<ApiResource> ApiResources { get; } = new[]
        {
            new ApiResource("api", "My API")
        };

        public static IEnumerable<Client> Clients { get; } = new[]
        {
            new Client
            {
                AllowedGrantTypes = GrantTypes.ClientCredentials,
                AllowedScopes = new[] {"api"},

                ClientId = "client",
                ClientSecrets = new[] {new Secret("secret".Sha256())}
            }
        };

        public static IEnumerable<IdentityResource> IdentityResources { get; } = new[]
        {
            new IdentityResources.OpenId()
        };
    }
}