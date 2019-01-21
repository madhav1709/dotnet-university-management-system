using System.ComponentModel.DataAnnotations;

namespace UniversityManagementSystem.Membership.WebApi.ViewModels
{
    public class ClaimViewModel
    {
        [Required] public string Type { get; set; }

        [Required] public string Value { get; set; }
    }
}