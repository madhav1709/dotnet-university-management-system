using System.ComponentModel.DataAnnotations;

namespace UniversityManagementSystem.Apps.WebApi.Models
{
    public class Course
    {
        public int Id { get; set; }

        [Required] public string Name { get; set; }

        [Required] public School School { get; set; }
    }
}