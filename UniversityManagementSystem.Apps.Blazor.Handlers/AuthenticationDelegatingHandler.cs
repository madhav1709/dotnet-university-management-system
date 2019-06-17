using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using UniversityManagementSystem.Apps.Blazor.Services;
using static System.Net.HttpStatusCode;

namespace UniversityManagementSystem.Apps.Blazor.Handlers
{
    public class AuthenticationDelegatingHandler : DelegatingHandler
    {
        public AuthenticationDelegatingHandler(IAuthenticationService authenticationService)
        {
            AuthenticationService = authenticationService;
        }

        private IAuthenticationService AuthenticationService { get; }

        protected override async Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request,
            CancellationToken cancellationToken
        )
        {
            var response = await base.SendAsync(request, cancellationToken);

            if (response.StatusCode == Unauthorized) await AuthenticationService.LoginAsync();

            return response;
        }
    }
}