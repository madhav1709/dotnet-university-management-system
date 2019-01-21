using System.ComponentModel.DataAnnotations;

namespace UniversityManagementSystem.Membership.WebApi.ViewModels
{
    public class RoleViewModel
    {
        public string Id { get; set; }

        [Required] public string Name { get; set; }
    }
}