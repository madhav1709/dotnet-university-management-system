using System.ComponentModel.DataAnnotations;

namespace UniversityManagementSystem.Apps.WebApi.Models
{
    public class School
    {
        public int Id { get; set; }

        [Required] public string Name { get; set; }

        [Required] public Campus Campus { get; set; }
    }
}