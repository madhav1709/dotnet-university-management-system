using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using UniversityManagementSystem.Identity.Data.Contexts;
using UniversityManagementSystem.Identity.Data.Entities;

namespace UniversityManagementSystem.Identity
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();

            ConfigureContexts(services);

            ConfigureIdentity(services);

            ConfigureAuthorization(services);

            ConfigureAuthentication(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();
            else
                app.UseHsts();

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseIdentityServer();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(builder => { builder.MapRazorPages(); });
        }

        private void ConfigureAuthentication(IServiceCollection services)
        {
            services.AddAuthentication()
                .AddIdentityServerJwt()
                .AddFacebook(options =>
                {
                    options.AppId = Configuration["Authentication:Facebook:AppId"];
                    options.AppSecret = Configuration["Authentication:Facebook:AppSecret"];
                });
        }

        private void ConfigureAuthorization(IServiceCollection services)
        {
            services.AddIdentityServer()
                .AddApiAuthorization<ApplicationUser, ApplicationDbContext>(options =>
                {
                    options.ApiResources = Config.ApiResources;
                    options.Clients = Config.Clients;
                });
        }

        private void ConfigureContexts(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(ConfigureDbContext);
        }

        private void ConfigureDbContext(DbContextOptionsBuilder builder)
        {
            var connectionString = Configuration.GetConnectionString("Default");

            builder.UseSqlServer(connectionString);
        }

        private void ConfigureIdentity(IServiceCollection services)
        {
            services.AddDefaultIdentity<ApplicationUser>(options => { options.User.RequireUniqueEmail = true; })
                .AddEntityFrameworkStores<ApplicationDbContext>();
        }
    }
}