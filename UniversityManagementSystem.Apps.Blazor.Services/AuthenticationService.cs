using System.Threading.Tasks;
using Microsoft.JSInterop;
using UniversityManagementSystem.Apps.Blazor.Models;
using static System.String;
using static UniversityManagementSystem.Apps.Blazor.Models.User;

namespace UniversityManagementSystem.Apps.Blazor.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        public AuthenticationService(IJSRuntime jsRuntime)
        {
            JsRuntime = jsRuntime;
        }

        private IJSRuntime JsRuntime { get; }

        public async Task<User> GetUserAsync()
        {
            var json = await JsRuntime.InvokeAsync<string>("functions.getUser");

            return !IsNullOrEmpty(json) ? FromJson(json) : null;
        }

        public async Task LoginAsync(string callback = "redirect")
        {
            await JsRuntime.InvokeAsync<string>("functions.login", callback);
        }

        public async Task LogoutAsync(string callback = "redirect")
        {
            await JsRuntime.InvokeAsync<object>("functions.logout", callback);
        }
    }
}