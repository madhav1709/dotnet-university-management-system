using System.ComponentModel.DataAnnotations;

namespace UniversityManagementSystem.Apps.WebApi.Models
{
    public class Run
    {
        public int Id { get; set; }

        [Required] public int Year { get; set; }

        [Required] public string Semester { get; set; }

        [Required] public string LecturerId { get; set; }

        [Required] public Module Module { get; set; }
    }
}