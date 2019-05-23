using System.Collections.Generic;
using IdentityServer4.Models;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;

namespace UniversityManagementSystem.Identity
{
    public static class Config
    {
        static Config()
        {
            ApiResources = new ApiResourceCollection
            {
                new ApiResource("https://localhost:5001", "University Management System API")
            };
            
            Clients = new ClientCollection
            {
                new Client
                {
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    AllowedScopes = new List<string>
                    {
                        "https://localhost:5001"
                    },

                    ClientId = "client",
                    ClientSecrets = new List<Secret>
                    {
                        new Secret("secret".Sha256())
                    }
                }
            };
        }

        public static ApiResourceCollection ApiResources { get; }

        public static ClientCollection Clients { get; }
    }
}