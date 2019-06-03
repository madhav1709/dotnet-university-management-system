using System;
using System.Reflection;
using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using Swashbuckle.AspNetCore.SwaggerUI;
using UniversityManagementSystem.Apps.WebApi.Profiles;
using UniversityManagementSystem.Data.Contexts;
using UniversityManagementSystem.Services;
using static Microsoft.OpenApi.Models.SecuritySchemeType;

namespace UniversityManagementSystem.Apps.WebApi
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

            void AuthenticationOptionsAction(AuthenticationOptions options)
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }

            void CorsOptionsAction(CorsOptions options)
            {
                options.AddDefaultPolicy(CorsPolicyAction);
            }

            void CorsPolicyAction(CorsPolicyBuilder builder)
            {
                builder.WithOrigins("https://localhost:5002").WithHeaders("Authorization");
            }

            void DbContextOptionsAction(DbContextOptionsBuilder builder)
            {
                var connectionString = Configuration.GetConnectionString("Default");

                builder.UseSqlServer(connectionString, SqlServerOptionsAction);
            }

            void JwtBearerOptionsAction(JwtBearerOptions options)
            {
                options.Audience = "api";
                options.Authority = "https://localhost:5000";
            }

            void SqlServerOptionsAction(SqlServerDbContextOptionsBuilder builder)
            {
                var migrationsAssembly = typeof(ApplicationDbContext).GetTypeInfo().Assembly.GetName().Name;

                builder.MigrationsAssembly(migrationsAssembly);
            }

            void SwaggerGenOptionsAction(SwaggerGenOptions options)
            {
                var bearerAuthSecurityScheme = new OpenApiSecurityScheme
                {
                    Scheme = "bearer",
                    Type = Http
                };
                var openIdSecurityScheme = new OpenApiSecurityScheme
                {
                    OpenIdConnectUrl = new Uri("https://localhost:5000/.well-known/openid-configuration"),
                    Type = OpenIdConnect
                };

                options.AddSecurityDefinition("BearerAuth", bearerAuthSecurityScheme);
                options.AddSecurityDefinition("OpenID", openIdSecurityScheme);

                var info = new OpenApiInfo
                {
                    Title = "University Management System",
                    Version = "v1"
                };

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
            }

            services.AddScoped<IAssignmentService, AssignmentService>()
                .AddScoped<IBookService, BookService>()
                .AddScoped<IBuildingService, BuildingService>()
                .AddScoped<ICampusService, CampusService>()
                .AddScoped<ICourseService, CourseService>()
                .AddScoped<IEnrolmentService, EnrolmentService>()
                .AddScoped<IGraduationService, GraduationService>()
                .AddScoped<ILectureService, LectureService>()
                .AddScoped<ILibraryService, LibraryService>()
                .AddScoped<IModuleService, ModuleService>()
                .AddScoped<IRefectoryService, RefectoryService>()
                .AddScoped<IRentalService, RentalService>()
                .AddScoped<IResultService, ResultService>()
                .AddScoped<IRoomService, RoomService>()
                .AddScoped<IRunService, RunService>()
                .AddScoped<ISchoolService, SchoolService>();

            services.AddAuthentication(AuthenticationOptionsAction)
                .AddJwtBearer(JwtBearerOptionsAction);

            services.AddAutoMapper(typeof(AssignmentProfile).GetTypeInfo().Assembly);

            services.AddDbContext<ApplicationDbContext>(DbContextOptionsAction);

            services.AddCors(CorsOptionsAction);

            services.AddSwaggerGen(SwaggerGenOptionsAction);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            void EndpointRouteAction(IEndpointRouteBuilder builder)
            {
                builder.MapControllers();
            }

            void SwaggerUiOptionsAction(SwaggerUIOptions options)
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "University Management System V1");
            }

            if (env.IsDevelopment())
            {
                app.UseDatabaseErrorPage();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseCors();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseHttpsRedirection();

            app.UseSwagger();
            app.UseSwaggerUI(SwaggerUiOptionsAction);

            app.UseEndpoints(EndpointRouteAction);
        }
    }
}