using System.ComponentModel.DataAnnotations;

namespace UniversityManagementSystem.Core.WebApi.ViewModels
{
    public class ModuleViewModel
    {
        public int Id { get; set; }

        [Required] public string Code { get; set; }

        [Required] public string Title { get; set; }
    }
}