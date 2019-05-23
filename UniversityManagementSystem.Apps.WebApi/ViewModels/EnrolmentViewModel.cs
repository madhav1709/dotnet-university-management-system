using System.ComponentModel.DataAnnotations;

namespace UniversityManagementSystem.Apps.WebApi.ViewModels
{
    public class EnrolmentViewModel
    {
        public int Id { get; set; }

        [Required] public int Year { get; set; }

        [Required] public string StudentId { get; set; }

        [Required] public RunViewModel Run { get; set; }
    }
}