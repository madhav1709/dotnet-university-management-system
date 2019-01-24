using System.ComponentModel.DataAnnotations;

namespace UniversityManagementSystem.Core.WebApi.ViewModels
{
    public class GraduationViewModel
    {
        public int Id { get; set; }

        [Required] public int Year { get; set; }

        [Required] public string StudentId { get; set; }

        [Required] public CourseViewModel Course { get; set; }
    }
}