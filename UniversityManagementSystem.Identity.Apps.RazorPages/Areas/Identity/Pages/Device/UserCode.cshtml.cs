using System;
using System.ComponentModel.DataAnnotations;
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
    public class UserCodeModel : PageModel
    {
        public UserCodeModel(
            IClientStore clientStore,
            IIdentityServerInteractionService interactionService,
            ILogger<UserCodeModel> logger,
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

        private ILogger<UserCodeModel> Logger { get; }

        private IResourceStore ResourceStore { get; }

        [BindProperty] public InputModel Input { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                await ValidateInputModelAsync();

                return RedirectToPage("/Device/UserCodeConfirmation",
                    new {area = "Identity", userCode = Input.UserCode});
            }
            catch (Exception exception)
            {
                Logger.LogError(exception.Message);

                return RedirectToPage("/Error", new {area = "Identity"});
            }
        }

        private async Task ValidateInputModelAsync()
        {
            var authorizationRequest = await InteractionService.GetAuthorizationContextAsync(Input.UserCode);
            if (authorizationRequest == null)
                throw new Exception($"No consent request matching authorization request: {Input.UserCode}");

            var client = await ClientStore.FindEnabledClientByIdAsync(authorizationRequest.ClientId);
            if (client == null)
                throw new Exception($"Invalid client id: {authorizationRequest.ClientId}");

            var scopesRequested = authorizationRequest.ScopesRequested.ToList();
            var resources = await ResourceStore.FindEnabledResourcesByScopeAsync(scopesRequested);
            if (resources == null || !resources.IdentityResources.Any() && !resources.ApiResources.Any())
                throw new Exception($"No scopes matching: {Join(", ", scopesRequested)}");
        }

        public class InputModel
        {
            [Required] public string UserCode { get; set; }
        }
    }
}