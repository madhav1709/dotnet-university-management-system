using System.Threading.Tasks;
using Microsoft.JSInterop;
using UniversityManagementSystem.Apps.Blazor.Models;

namespace UniversityManagementSystem.Apps.Blazor.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        public AuthenticationService(IJSRuntime jsRuntime)
        {
            JsRuntime = jsRuntime;
        }

        private IJSRuntime JsRuntime { get; }

        private TaskCompletionSource<User> TaskCompletionSource { get; set; }

        public async Task<User> GetUserAsync()
        {
            TaskCompletionSource = new TaskCompletionSource<User>();

            await JsRuntime.InvokeAsync<object>("user", new DotNetObjectRef(this));

            var user = await TaskCompletionSource.Task;

            return user;
        }

        public async Task LoginAsync()
        {
            await JsRuntime.InvokeAsync<object>("login", new DotNetObjectRef(this));
        }

        public async Task LogoutAsync()
        {
            await JsRuntime.InvokeAsync<object>("logout", new DotNetObjectRef(this));
        }

        [JSInvokable]
        public void OnUser(string json = null)
        {
            var user = json != null ? User.FromJson(json) : null;

            TaskCompletionSource?.SetResult(user);
        }
    }
}