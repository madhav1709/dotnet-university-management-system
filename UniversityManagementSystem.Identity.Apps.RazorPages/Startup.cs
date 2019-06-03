using System.Reflection;
using IdentityServer4.Configuration;
using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.Authentication.Facebook;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using UniversityManagementSystem.Identity.Data.Contexts;
using UniversityManagementSystem.Identity.Data.Entities;
using static Microsoft.AspNetCore.Mvc.CompatibilityVersion;

namespace UniversityManagementSystem.Identity.Apps.RazorPages
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;
        }

        public IConfiguration Configuration { get; }

        public IWebHostEnvironment Environment { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();

            void ConfigurationStoreOptionsAction(ConfigurationStoreOptions options)
            {
                options.IdentityResource.Name = "IdentityServerIdentityResources";
                options.IdentityClaim.Name = "IdentityServerIdentityClaims";
                options.ApiResource.Name = "IdentityServerApiResources";
                options.ApiSecret.Name = "IdentityServerApiSecrets";
                options.ApiScope.Name = "IdentityServerApiScopes";
                options.ApiClaim.Name = "IdentityServerApiClaims";
                options.ApiScopeClaim.Name = "IdentityServerApiScopeClaims";
                options.Client.Name = "IdentityServerClients";
                options.ClientGrantType.Name = "IdentityServerClientGrantTypes";
                options.ClientRedirectUri.Name = "IdentityServerClientRedirectUris";
                options.ClientPostLogoutRedirectUri.Name = "IdentityServerClientPostLogoutRedirectUris";
                options.ClientScopes.Name = "IdentityServerClientScopes";
                options.ClientSecret.Name = "IdentityServerClientSecrets";
                options.ClientClaim.Name = "IdentityServerClientClaims";
                options.ClientIdPRestriction.Name = "IdentityServerClientIdPRestrictions";
                options.ClientCorsOrigin.Name = "IdentityServerClientCorsOrigins";
                options.ClientProperty.Name = "IdentityServerClientProperties";
                options.ApiResourceProperty.Name = "IdentityServerApiResourceProperties";
                options.IdentityResourceProperty.Name = "IdentityServerIdentityResourceProperties";

                options.ConfigureDbContext = DbContextOptionsAction;
            }

            void DbContextOptionsAction(DbContextOptionsBuilder builder)
            {
                var connectionString = Configuration.GetConnectionString("Default");

                builder.UseSqlServer(connectionString, SqlServerOptionsAction);
            }

            void FacebookOptionsAction(FacebookOptions options)
            {
                // https://docs.microsoft.com/en-gb/aspnet/core/security/authentication/social/facebook-logins?view=aspnetcore-3.0#store-facebook-app-id-and-app-secret
                options.AppId = Configuration["Authentication:Facebook:AppId"];
                options.AppSecret = Configuration["Authentication:Facebook:AppSecret"];
            }

            void IdentityOptionsAction(IdentityOptions options)
            {
                options.User.RequireUniqueEmail = true;
            }

            void IdentityServerOptionsAction(IdentityServerOptions options)
            {
                options.Events.RaiseSuccessEvents = true;
                options.Events.RaiseFailureEvents = true;
                options.Events.RaiseInformationEvents = true;
                options.Events.RaiseErrorEvents = true;

                options.UserInteraction.LoginUrl = "/Identity/Account/Login";
                options.UserInteraction.LoginReturnUrlParameter = "ReturnUrl";
                options.UserInteraction.LogoutUrl = "/Identity/Account/Logout";
                options.UserInteraction.LogoutIdParameter = "LogoutId";
                options.UserInteraction.ConsentUrl = "/Identity/Consent";
                options.UserInteraction.ConsentReturnUrlParameter = "ReturnUrl";
                options.UserInteraction.ErrorUrl = "/Identity/Error";
                options.UserInteraction.ErrorIdParameter = "ErrorId";
                options.UserInteraction.CustomRedirectReturnUrlParameter = "ReturnUrl";
                options.UserInteraction.DeviceVerificationUrl = "/Identity/Device";
                options.UserInteraction.DeviceVerificationUserCodeParameter = "UserCode";
            }

            void OperationalStoreOptionsAction(OperationalStoreOptions options)
            {
                options.PersistedGrants.Name = "IdentityServerPersistedGrants";
                options.DeviceFlowCodes.Name = "IdentityServerDeviceFlowCodes";

                options.EnableTokenCleanup = true;

                options.ConfigureDbContext = DbContextOptionsAction;
            }

            void SqlServerOptionsAction(SqlServerDbContextOptionsBuilder builder)
            {
                var migrationsAssembly = typeof(ApplicationDbContext).GetTypeInfo().Assembly.GetName().Name;

                builder.MigrationsAssembly(migrationsAssembly);
            }

            services.AddRazorPages()
                .SetCompatibilityVersion(Version_3_0);

            services.AddDbContext<ApplicationDbContext>(DbContextOptionsAction);

            services.AddDefaultIdentity<ApplicationUser>(IdentityOptionsAction)
                .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddIdentityServer(IdentityServerOptionsAction)
                .AddConfigurationStore<ApplicationDbContext>(ConfigurationStoreOptionsAction)
                .AddOperationalStore<ApplicationDbContext>(OperationalStoreOptionsAction)
                .AddAspNetIdentity<ApplicationUser>()
                .AddDeveloperSigningCredential();

            services.AddAuthentication()
                .AddFacebook(FacebookOptionsAction);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {
            void EndpointRouteBuilderAction(IEndpointRouteBuilder builder)
            {
                builder.MapRazorPages();
            }

            Config.InitializeDatabaseAsync(app.ApplicationServices).Wait();

            if (Environment.IsDevelopment())
            {
                app.UseDatabaseErrorPage();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseIdentityServer();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(EndpointRouteBuilderAction);
        }
    }
}