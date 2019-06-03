using System.Diagnostics;
using System.Threading.Tasks;
using IdentityServer4.Models;
using IdentityServer4.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace UniversityManagementSystem.Identity.Apps.RazorPages.Areas.Identity.Pages
{
    [AllowAnonymous]
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public class ErrorModel : PageModel
    {
        public ErrorModel(IIdentityServerInteractionService interactionService)
        {
            InteractionService = interactionService;
        }

        private IIdentityServerInteractionService InteractionService { get; }

        public ErrorMessage ErrorMessage { get; set; }

        public bool ShowErrorMessage => ErrorMessage != null;

        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);

        public async Task OnGetAsync(string errorId)
        {
            if (!string.IsNullOrEmpty(errorId)) ErrorMessage = await InteractionService.GetErrorContextAsync(errorId);

            RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
        }
    }
}