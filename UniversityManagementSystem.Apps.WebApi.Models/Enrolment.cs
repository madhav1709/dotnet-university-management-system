using System.ComponentModel.DataAnnotations;

namespace UniversityManagementSystem.Apps.WebApi.Models
{
    public class Enrolment
    {
        public int Id { get; set; }

        [Required] public int Year { get; set; }

        [Required] public string StudentId { get; set; }

        [Required] public Run Run { get; set; }
    }
}