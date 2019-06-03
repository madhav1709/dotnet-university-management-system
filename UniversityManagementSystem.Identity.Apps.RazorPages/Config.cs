using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer4.EntityFramework.Mappers;
using IdentityServer4.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using UniversityManagementSystem.Identity.Data.Contexts;
using static IdentityServer4.IdentityServerConstants.StandardScopes;

namespace UniversityManagementSystem.Identity.Apps.RazorPages
{
    public static class Config
    {
        static Config()
        {
            ApiResources = new List<ApiResource>
            {
                new ApiResource("api", "API")
            };

            Clients = new List<Client>
            {
                new Client
                {
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    AllowedScopes = new List<string>
                    {
                        "api"
                    },

                    ClientId = "client",
                    ClientName = "Client",
                    ClientSecrets = new List<Secret>
                    {
                        new Secret("secret".Sha256())
                    }
                },
                new Client
                {
                    AllowedCorsOrigins = new List<string>
                    {
                        "https://localhost:5002"
                    },
                    AllowedGrantTypes = GrantTypes.Code,
                    AllowedScopes = new List<string>
                    {
                        "api",
                        OpenId,
                        Profile
                    },

                    ClientId = "blazor",
                    ClientName = "Blazor",

                    RequireClientSecret = false,
                    RequirePkce = true,

                    RedirectUris = new List<string>
                    {
                        "https://localhost:5002/callback.html"
                    },
                    PostLogoutRedirectUris = new List<string>
                    {
                        "https://localhost:5002"
                    }
                }
            };

            IdentityResources = new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile()
            };
        }

        private static IEnumerable<ApiResource> ApiResources { get; }

        private static IEnumerable<Client> Clients { get; }

        private static IEnumerable<IdentityResource> IdentityResources { get; }

        public static async Task InitializeDatabaseAsync(IServiceProvider serviceProvider)
        {
            using (var serviceScope = serviceProvider.CreateScope())
            {
                await serviceScope.ServiceProvider.GetService<ApplicationDbContext>().Database.MigrateAsync();

                await AddSeedDataAsync(
                    serviceScope.ServiceProvider,
                    client => client.ClientId,
                    Clients.Select(ClientMappers.ToEntity).ToList()
                );

                await AddSeedDataAsync(
                    serviceScope.ServiceProvider,
                    identityResource => identityResource.Name,
                    IdentityResources.Select(IdentityResourceMappers.ToEntity).ToList()
                );

                await AddSeedDataAsync(
                    serviceScope.ServiceProvider,
                    apiResource => apiResource.Name,
                    ApiResources.Select(ApiResourceMappers.ToEntity).ToList()
                );
            }
        }

        private static async Task AddSeedDataAsync<TEntity, TProperty>(
            IServiceProvider serviceProvider,
            Func<TEntity, TProperty> propertySelector,
            IEnumerable<TEntity> entities
        ) where TEntity : class
        {
            List<TEntity> dbEntities;

            // Queries in a separate context so that we can attach existing entities as modified.
            using (var serviceScope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
            using (var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>())
            {
                dbEntities = context.Set<TEntity>().ToList();
            }

            // Saves in a separate context so that we can attach existing entities as modified.
            using (var serviceScope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
            using (var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>())
            {
                foreach (var entity in entities)
                {
                    bool EntityPredicate(TEntity dbEntity)
                    {
                        return propertySelector(dbEntity).Equals(propertySelector(entity));
                    }

                    if (!dbEntities.Any(EntityPredicate)) context.Add(entity);
                }

                await context.SaveChangesAsync();
            }
        }
    }
}