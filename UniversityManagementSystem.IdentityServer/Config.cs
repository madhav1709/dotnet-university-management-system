using System.Collections.Generic;
using IdentityServer4.Models;

namespace UniversityManagementSystem.IdentityServer
{
    public static class Config
    {
        public static IEnumerable<ApiResource> ApiResources { get; } = new[]
        {
            new ApiResource("https://localhost:5001", "Membership API")
        };

        public static IEnumerable<Client> Clients { get; } = new[]
        {
            new Client
            {
                AllowedGrantTypes = GrantTypes.ClientCredentials,
                AllowedScopes = new[] {"https://localhost:5001"},

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