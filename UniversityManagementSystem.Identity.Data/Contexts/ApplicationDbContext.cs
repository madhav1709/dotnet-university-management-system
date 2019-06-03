using System.Threading.Tasks;
using IdentityServer4.EntityFramework.Entities;
using IdentityServer4.EntityFramework.Extensions;
using IdentityServer4.EntityFramework.Interfaces;
using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using UniversityManagementSystem.Identity.Data.Entities;

namespace UniversityManagementSystem.Identity.Data.Contexts
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>,
        IConfigurationDbContext, IPersistedGrantDbContext
    {
        public ApplicationDbContext(
            DbContextOptions<ApplicationDbContext> options,
            ConfigurationStoreOptions configurationStoreOptions,
            OperationalStoreOptions operationalStoreOptions
        ) : base(options)
        {
            ConfigurationStoreOptions = configurationStoreOptions;
            OperationalStoreOptions = operationalStoreOptions;
        }

        private ConfigurationStoreOptions ConfigurationStoreOptions { get; }

        private OperationalStoreOptions OperationalStoreOptions { get; }

        public DbSet<Client> Clients { get; set; }

        public DbSet<IdentityResource> IdentityResources { get; set; }

        public DbSet<ApiResource> ApiResources { get; set; }

        async Task<int> IConfigurationDbContext.SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }

        public DbSet<PersistedGrant> PersistedGrants { get; set; }

        public DbSet<DeviceFlowCodes> DeviceFlowCodes { get; set; }

        async Task<int> IPersistedGrantDbContext.SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ConfigureClientContext(ConfigurationStoreOptions);
            modelBuilder.ConfigureResourcesContext(ConfigurationStoreOptions);

            modelBuilder.ConfigurePersistedGrantContext(OperationalStoreOptions);

            base.OnModelCreating(modelBuilder);
        }
    }
}