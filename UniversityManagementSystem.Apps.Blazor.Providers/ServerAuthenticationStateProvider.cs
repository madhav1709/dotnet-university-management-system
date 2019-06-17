using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using UniversityManagementSystem.Apps.Blazor.Services;
using static System.Security.Claims.ClaimTypes;
using static Microsoft.JSInterop.DotNetObjectRef;

namespace UniversityManagementSystem.Apps.Blazor.Providers
{
    public class ServerAuthenticationStateProvider : AuthenticationStateProvider
    {
        public ServerAuthenticationStateProvider(
            IAuthenticationService authenticationService,
            HttpClient httpClient,
            IJSRuntime jsRuntime
        )
        {
            AuthenticationService = authenticationService;
            HttpClient = httpClient;
            JsRuntime = jsRuntime;
            
            JsRuntime.InvokeAsync<object>("functions.registerEvents", Create(this));
        }

        private IAuthenticationService AuthenticationService { get; }
        
        private HttpClient HttpClient { get; }

        private IJSRuntime JsRuntime { get; }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var user = await AuthenticationService.GetUserAsync();

            ClaimsPrincipal claimsPrincipal;

            if (user != null)
            {
                HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", user.AccessToken);

                var claims = new List<Claim>
                {
                    new Claim(Name, user.Profile.Name),
                    new Claim(NameIdentifier, user.Profile.Sub.ToString())
                };

                var claimsIdentity = new ClaimsIdentity(claims, "Password");

                claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
            }
            else
            {
                HttpClient.DefaultRequestHeaders.Authorization = null;

                claimsPrincipal = new ClaimsPrincipal();
            }

            return new AuthenticationState(claimsPrincipal);
        }

        [JSInvokable]
        public async Task OnAuthenticationStateChanged(string @event)
        {
            Console.WriteLine($"OnAuthenticationStateChanged: {@event}");
            
            var task = GetAuthenticationStateAsync();

            NotifyAuthenticationStateChanged(task);

            switch (@event)
            {
                case "userLoaded":
                case "userUnloaded":
                    break;
                case "accessTokenExpired":
                case "silentRenewError":
                    await AuthenticationService.LoginAsync();

                    break;
                case "userSignedOut":
                    await AuthenticationService.LogoutAsync();

                    break;
                default:
                    throw new ArgumentOutOfRangeException(@event);
            }
        }
    }
}