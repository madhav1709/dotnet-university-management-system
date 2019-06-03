using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer4.Events;
using IdentityServer4.Extensions;
using IdentityServer4.Models;
using IdentityServer4.Services;
using IdentityServer4.Stores;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using UniversityManagementSystem.Identity.Apps.RazorPages.Views.Shared;
using UniversityManagementSystem.Identity.Extensions;
using static System.String;
using static IdentityServer4.IdentityServerConstants.StandardScopes;
using static UniversityManagementSystem.Identity.Apps.RazorPages.Models.ConsentOptions;

namespace UniversityManagementSystem.Identity.Apps.RazorPages.Areas.Identity.Pages.Consent
{
    [Authorize]
    [ValidateAntiForgeryToken]
    public class IndexModel : PageModel
    {
        public IndexModel(
            IClientStore clientStore,
            IEventService eventService,
            IIdentityServerInteractionService interactionService,
            ILogger<IndexModel> logger,
            IResourceStore resourceStore
        )
        {
            ClientStore = clientStore;
            EventService = eventService;
            InteractionService = interactionService;
            Logger = logger;
            ResourceStore = resourceStore;
        }

        private IClientStore ClientStore { get; }

        private IEventService EventService { get; }

        private IIdentityServerInteractionService InteractionService { get; }

        private ILogger<IndexModel> Logger { get; }

        private IResourceStore ResourceStore { get; }

        [BindProperty] public InputModel Input { get; set; }

        public string ClientName { get; set; }

        public string ClientUrl { get; set; }

        public string ClientLogoUrl { get; set; }

        public bool AllowRememberConsent { get; set; }

        public IEnumerable<ScopePartialModel> IdentityScopes { get; set; }

        public IEnumerable<ScopePartialModel> ResourceScopes { get; set; }

        public string ReturnUrl { get; set; }

        public async Task<IActionResult> OnGetAsync([FromQuery] string returnUrl = null)
        {
            ReturnUrl = returnUrl;

            try
            {
                await BuildPageModelAsync();

                return Page();
            }
            catch (Exception exception)
            {
                Logger.LogError(exception.Message);

                return RedirectToPage("/Error", new {area = "Identity"});
            }
        }

        public async Task<IActionResult> OnPostAsync([FromQuery] string returnUrl = null,
            [FromForm] InputModel input = null)
        {
            ReturnUrl = returnUrl ??= Url.Content("~/");

            var authorizationRequest = await InteractionService.GetAuthorizationContextAsync(returnUrl);

            if (authorizationRequest == null || input == null) return RedirectToPage("/Error", new {area = "Identity"});

            ConsentResponse consentResponse;

            switch (input.Button)
            {
                case "no":
                    consentResponse = ConsentResponse.Denied;

                    await EventService.RaiseAsync(
                        new ConsentDeniedEvent(
                            User.GetSubjectId(),
                            authorizationRequest.ClientId,
                            authorizationRequest.ScopesRequested
                        )
                    );

                    break;
                case "yes" when input.ScopesConsented != null && input.ScopesConsented.Any():
                    var scopes = input.ScopesConsented;

                    if (!EnableOfflineAccess) scopes = scopes.Where(scope => scope != OfflineAccess);

                    consentResponse = new ConsentResponse
                    {
                        RememberConsent = input.RememberConsent,
                        ScopesConsented = scopes.ToList()
                    };

                    await EventService.RaiseAsync(
                        new ConsentGrantedEvent(
                            User.GetSubjectId(),
                            authorizationRequest.ClientId,
                            authorizationRequest.ScopesRequested,
                            consentResponse.ScopesConsented,
                            consentResponse.RememberConsent
                        )
                    );

                    break;
                case "yes":
                    ModelState.AddModelError(Empty, MustChooseOneErrorMessage);

                    await BuildPageModelAsync(input);

                    return Page();
                default:
                    ModelState.AddModelError(Empty, InvalidSelectionErrorMessage);

                    await BuildPageModelAsync(input);

                    return Page();
            }

            await InteractionService.GrantConsentAsync(authorizationRequest, consentResponse);

            return await ClientStore.IsPkceClientAsync(authorizationRequest.ClientId)
                ? (IActionResult) RedirectToPage("/Redirect", new {area = "Identity", redirectUrl = returnUrl})
                : Redirect(returnUrl);
        }

        private async Task BuildPageModelAsync(InputModel input = null)
        {
            var authorizationRequest = await InteractionService.GetAuthorizationContextAsync(ReturnUrl);
            if (authorizationRequest == null)
                throw new Exception($"No consent request matching authorization request: {ReturnUrl}");

            var client = await ClientStore.FindEnabledClientByIdAsync(authorizationRequest.ClientId);
            if (client == null)
                throw new Exception($"Invalid client id: {authorizationRequest.ClientId}");

            var scopesRequested = authorizationRequest.ScopesRequested.ToList();
            var resources = await ResourceStore.FindEnabledResourcesByScopeAsync(scopesRequested);
            if (resources == null || !resources.IdentityResources.Any() && !resources.ApiResources.Any())
                throw new Exception($"No scopes matching: {Join(", ", scopesRequested)}");

            Input = new InputModel
            {
                ScopesConsented = input?.ScopesConsented?.ToList() ?? new List<string>(),
                RememberConsent = input?.RememberConsent ?? true
            };

            ClientName = client.ClientName ?? client.ClientId;
            ClientUrl = client.ClientUri;
            ClientLogoUrl = client.LogoUri;
            AllowRememberConsent = client.AllowRememberConsent;

            ScopePartialModel IdentityResourceSelector(IdentityResource identityResource)
            {
                return new ScopePartialModel(
                    Input.ScopesConsented.Contains(identityResource.Name) || input == null,
                    identityResource
                );
            }

            IdentityScopes = resources.IdentityResources
                .Select(IdentityResourceSelector)
                .ToList();

            IEnumerable<Scope> ApiResourceSelector(ApiResource apiResource)
            {
                return apiResource.Scopes;
            }

            ScopePartialModel ScopeSelector(Scope scope)
            {
                return new ScopePartialModel(
                    Input.ScopesConsented.Contains(scope.Name) || input == null,
                    scope
                );
            }

            ResourceScopes = resources.ApiResources
                .SelectMany(ApiResourceSelector)
                .Select(ScopeSelector)
                .ToList();

            if (EnableOfflineAccess && resources.OfflineAccess)
                ResourceScopes = ResourceScopes.Union(
                    new[]
                    {
                        new ScopePartialModel(Input.ScopesConsented.Contains(OfflineAccess) || input == null)
                    }
                );
        }

        public class InputModel
        {
            public string Button { get; set; }

            public IEnumerable<string> ScopesConsented { get; set; }

            [DisplayName("Remember my decision")] public bool RememberConsent { get; set; }
        }
    }
}