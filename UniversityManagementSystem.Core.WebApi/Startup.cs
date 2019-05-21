using System;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using UniversityManagementSystem.Core.Data.Contexts;
using UniversityManagementSystem.Core.Services;
using UniversityManagementSystem.Core.WebApi.Mappings;

namespace UniversityManagementSystem.Core.WebApi
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

            services.AddScoped<IAssignmentService, AssignmentService>();
            services.AddScoped<IBookService, BookService>();
            services.AddScoped<ICampusService, CampusService>();
            services.AddScoped<ICourseService, CourseService>();
            services.AddScoped<IEnrolmentService, EnrolmentService>();
            services.AddScoped<IGraduationService, GraduationService>();
            services.AddScoped<IHallService, HallService>();
            services.AddScoped<ILectureService, LectureService>();
            services.AddScoped<ILibraryService, LibraryService>();
            services.AddScoped<IModuleService, ModuleService>();
            services.AddScoped<IRentalService, RentalService>();
            services.AddScoped<IResultService, ResultService>();
            services.AddScoped<IRoomService, RoomService>();
            services.AddScoped<IRunService, RunService>();

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
                    "University Management System Core API V1"
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
                options.Audience = "https://localhost:5002";
                options.Authority = "https://localhost:5000";
            });
        }

        private void ConfigureAutoMapper(IServiceCollection services)
        {
            Mapper.Initialize(expression =>
            {
                expression.AddProfile<AssignmentMappingProfile>();
                expression.AddProfile<BookMappingProfile>();
                expression.AddProfile<CampusMappingProfile>();
                expression.AddProfile<CourseMappingProfile>();
                expression.AddProfile<EnrolmentMappingProfile>();
                expression.AddProfile<GraduationMappingProfile>();
                expression.AddProfile<HallMappingProfile>();
                expression.AddProfile<LectureMappingProfile>();
                expression.AddProfile<LibraryMappingProfile>();
                expression.AddProfile<ModuleMappingProfile>();
                expression.AddProfile<RentalMappingProfile>();
                expression.AddProfile<ResultMappingProfile>();
                expression.AddProfile<RoomMappingProfile>();
                expression.AddProfile<RunMappingProfile>();
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

                var info = new OpenApiInfo {Title = "University Management System Core API", Version = "v1"};

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