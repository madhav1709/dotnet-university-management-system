using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using UniversityManagementSystem.Apps.Blazor.Services;
using static System.Net.HttpStatusCode;

namespace UniversityManagementSystem.Apps.Blazor.Handlers
{
    public class AuthenticationHandler : DelegatingHandler
    {
        public AuthenticationHandler(IAuthenticationService authenticationService)
        {
            AuthenticationService = authenticationService;
        }

        private IAuthenticationService AuthenticationService { get; }

        protected override async Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request,
            CancellationToken cancellationToken
        )
        {
            var user = await AuthenticationService.GetUserAsync();

            if (user != null) request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", user.AccessToken);

            var response = await base.SendAsync(request, cancellationToken);

            if (response.StatusCode == Unauthorized) await AuthenticationService.LoginAsync();

            return response;
        }
    }
}