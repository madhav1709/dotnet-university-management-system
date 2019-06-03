using IdentityServer4.Models;
using static IdentityServer4.IdentityServerConstants.StandardScopes;
using static UniversityManagementSystem.Identity.Apps.RazorPages.Models.ConsentOptions;

namespace UniversityManagementSystem.Identity.Apps.RazorPages.Views.Shared
{
    public class ScopePartialModel
    {
        public ScopePartialModel()
        {
        }

        public ScopePartialModel(bool @checked)
        {
            Name = OfflineAccess;
            DisplayName = OfflineAccessDisplayName;
            Description = OfflineAccessDescription;
            Emphasize = true;
            Checked = @checked;
        }

        public ScopePartialModel(bool @checked, IdentityResource identityResource)
        {
            Name = identityResource.Name;
            DisplayName = identityResource.DisplayName;
            Description = identityResource.Description;
            Emphasize = identityResource.Emphasize;
            Required = identityResource.Required;
            Checked = @checked || identityResource.Required;
        }

        public ScopePartialModel(bool @checked, Scope scope)
        {
            Name = scope.Name;
            DisplayName = scope.DisplayName;
            Description = scope.Description;
            Emphasize = scope.Emphasize;
            Required = scope.Required;
            Checked = @checked || scope.Required;
        }

        public string Name { get; set; }

        public string DisplayName { get; set; }

        public string Description { get; set; }

        public bool Emphasize { get; set; }

        public bool Required { get; set; }

        public bool Checked { get; set; }
    }
}