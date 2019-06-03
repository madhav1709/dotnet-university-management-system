using System;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer4.Services;
using IdentityServer4.Stores;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using static System.String;

namespace UniversityManagementSystem.Identity.Apps.RazorPages.Areas.Identity.Pages.Device
{
    [Authorize]
    [ValidateAntiForgeryToken]
    public class IndexModel : PageModel
    {
        public IndexModel(
            IClientStore clientStore,
            IIdentityServerInteractionService interactionService,
            ILogger<IndexModel> logger,
            IResourceStore resourceStore
        )
        {
            ClientStore = clientStore;
            InteractionService = interactionService;
            Logger = logger;
            ResourceStore = resourceStore;
        }

        private IClientStore ClientStore { get; }

        private IIdentityServerInteractionService InteractionService { get; }

        private ILogger<IndexModel> Logger { get; }

        private IResourceStore ResourceStore { get; }

        public bool Success { get; set; }

        public string UserCode { get; set; }

        public async Task<IActionResult> OnGetAsync(string userCode = null)
        {
            UserCode = userCode;

            if (IsNullOrEmpty(userCode)) return RedirectToPage("/Device/UserCode", new {area = "Identity"});

            try
            {
                await ValidatePageModelAsync();

                return RedirectToPage("/Device/UserCodeConfirmation", new {area = "Identity", userCode});
            }
            catch (Exception exception)
            {
                Logger.LogError(exception.Message);

                return RedirectToPage("/Error", new {area = "Identity"});
            }
        }

        public void OnGetSuccess()
        {
            Success = true;
        }

        private async Task ValidatePageModelAsync()
        {
            var authorizationRequest = await InteractionService.GetAuthorizationContextAsync(UserCode);
            if (authorizationRequest == null)
                throw new Exception($"No consent request matching authorization request: {UserCode}");

            var client = await ClientStore.FindEnabledClientByIdAsync(authorizationRequest.ClientId);
            if (client == null)
                throw new Exception($"Invalid client id: {authorizationRequest.ClientId}");

            var scopesRequested = authorizationRequest.ScopesRequested.ToList();
            var resources = await ResourceStore.FindEnabledResourcesByScopeAsync(scopesRequested);
            if (resources == null || !resources.IdentityResources.Any() && !resources.ApiResources.Any())
                throw new Exception($"No scopes matching: {Join(", ", scopesRequested)}");
        }
    }
}