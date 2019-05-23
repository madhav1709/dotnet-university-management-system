using System.ComponentModel.DataAnnotations;

namespace UniversityManagementSystem.Apps.WebApi.ViewModels
{
    public class ResultViewModel
    {
        public int Id { get; set; }

        [Required] public int Grade { get; set; }

        [Required] public string Feedback { get; set; }

        [Required] public string StudentId { get; set; }

        [Required] public AssignmentViewModel Assignment { get; set; }
    }
}