using System;
using System.Net.Http;
using Microsoft.AspNetCore.Blazor.Http;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Builder;
using Microsoft.Extensions.DependencyInjection;
using UniversityManagementSystem.Apps.Blazor.Handlers;
using UniversityManagementSystem.Apps.Blazor.Providers;
using UniversityManagementSystem.Apps.Blazor.Services;

namespace UniversityManagementSystem.Apps.Blazor
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            HttpClient HttpClientImplementationFactory(IServiceProvider provider)
            {
                var authenticationService = provider.GetRequiredService<IAuthenticationService>();

                var authenticationDelegatingHandler = new AuthenticationDelegatingHandler(authenticationService)
                {
                    InnerHandler = new WebAssemblyHttpMessageHandler()
                };

                return new HttpClient(authenticationDelegatingHandler)
                {
                    BaseAddress = new Uri("https://localhost:5001/api/")
                };
            }

            services.AddSingleton<IAuthenticationService, AuthenticationService>();
            services.AddSingleton<AuthenticationStateProvider, ServerAuthenticationStateProvider>();

            services.AddSingleton(HttpClientImplementationFactory);

            services.AddAuthorizationCore();
        }

        public void Configure(IComponentsApplicationBuilder app)
        {
            app.AddComponent<App>("app");
        }
    }
}