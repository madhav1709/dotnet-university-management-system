using System.ComponentModel.DataAnnotations;

namespace UniversityManagementSystem.Apps.WebApi.Models
{
    public class Result
    {
        public int Id { get; set; }

        [Required] public int Grade { get; set; }

        [Required] public string Feedback { get; set; }

        [Required] public string StudentId { get; set; }

        [Required] public Assignment Assignment { get; set; }
    }
}