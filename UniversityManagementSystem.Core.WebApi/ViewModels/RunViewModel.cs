using System.ComponentModel.DataAnnotations;

namespace UniversityManagementSystem.Core.WebApi.ViewModels
{
    public class RunViewModel
    {
        public int Id { get; set; }

        [Required] public int Year { get; set; }

        [Required] public string Semester { get; set; }

        [Required] public ModuleViewModel Module { get; set; }
    }
}