using System;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using UniversityManagementSystem.Membership.Data.Contexts;
using UniversityManagementSystem.Membership.Data.Entities;
using UniversityManagementSystem.Membership.Services;
using UniversityManagementSystem.Membership.WebApi.Mappings;

namespace UniversityManagementSystem.Membership.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IUserService, UserService>();

            // Identity must come before Authentication, otherwise it overwrites the BearerAuth.
            ConfigureIdentity(services);

            // Authentication must come after Identity, because it overwrites the CookieAuth.
            ConfigureAuthentication(services);

            ConfigureAutoMapper(services);

            ConfigureContexts(services);

            ConfigureSwagger(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();
            else
                app.UseHsts();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseHttpsRedirection();

            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint(
                    "/swagger/v1/swagger.json",
                    "University Management System Membership API V1"
                );
            });

            app.UseEndpoints(builder => builder.MapControllers());
        }

        private void ConfigureAuthentication(IServiceCollection services)
        {
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.Audience = "https://localhost:5001";
                options.Authority = "https://localhost:5000";
            });
        }

        private void ConfigureAutoMapper(IServiceCollection services)
        {
            Mapper.Initialize(expression =>
            {
                expression.AddProfile<ClaimMappingProfile>();
                expression.AddProfile<RoleMappingProfile>();
                expression.AddProfile<UserMappingProfile>();
            });

            services.AddAutoMapper(typeof(Startup));
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
            const string allowedCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789_";

            services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.User.AllowedUserNameCharacters = allowedCharacters;
                options.User.RequireUniqueEmail = true;
            }).AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();
        }

        private void ConfigureSwagger(IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                var bearerAuthSecurityScheme = new OpenApiSecurityScheme
                {
                    Scheme = "bearer",
                    Type = SecuritySchemeType.Http
                };
                var openIdSecurityScheme = new OpenApiSecurityScheme
                {
                    OpenIdConnectUrl = new Uri("https://localhost:5000/.well-known/openid-configuration"),
                    Type = SecuritySchemeType.OpenIdConnect
                };

                options.AddSecurityDefinition("BearerAuth", bearerAuthSecurityScheme);
                options.AddSecurityDefinition("OpenID", openIdSecurityScheme);

                var info = new OpenApiInfo {Title = "University Management System Membership API", Version = "v1"};

                options.SwaggerDoc("v1", info);

                var securityRequirement = new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Id = "BearerAuth",
                                Type = ReferenceType.SecurityScheme
                            }
                        },
                        new string[] { }
                    },
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Id = "OpenID",
                                Type = ReferenceType.SecurityScheme
                            }
                        },
                        new string[] { }
                    }
                };

                options.AddSecurityRequirement(securityRequirement);
            });
        }
    }
}