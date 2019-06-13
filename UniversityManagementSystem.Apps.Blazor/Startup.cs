using System;
using System.Net.Http;
using Microsoft.AspNetCore.Blazor.Http;
using Microsoft.AspNetCore.Components.Builder;
using Microsoft.Extensions.DependencyInjection;
using UniversityManagementSystem.Apps.Blazor.Handlers;
using UniversityManagementSystem.Apps.Blazor.Services;

namespace UniversityManagementSystem.Apps.Blazor
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            HttpClient HttpClientImplementationFactory(IServiceProvider provider)
            {
                var authenticationHandler = provider.GetRequiredService<AuthenticationHandler>();
                authenticationHandler.InnerHandler = new WebAssemblyHttpMessageHandler();

                return new HttpClient(authenticationHandler)
                {
                    BaseAddress = new Uri("https://localhost:5001/api/")
                };
            }

            services.AddTransient<IAuthenticationService, AuthenticationService>();

            services.AddTransient<AuthenticationHandler>();

            services.AddSingleton(HttpClientImplementationFactory);
        }

        public void Configure(IComponentsApplicationBuilder app)
        {
            app.AddComponent<App>("app");
        }
    }
}