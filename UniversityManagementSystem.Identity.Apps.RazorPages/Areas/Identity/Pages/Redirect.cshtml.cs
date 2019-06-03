using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace UniversityManagementSystem.Identity.Apps.RazorPages.Areas.Identity.Pages
{
    public class RedirectModel : PageModel
    {
        public string RedirectUrl { get; set; }

        public void OnGet([FromQuery] string redirectUrl = null)
        {
            RedirectUrl = redirectUrl ??= Url.Content("~/");
        }
    }
}