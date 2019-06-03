using System.ComponentModel.DataAnnotations;

namespace UniversityManagementSystem.Apps.WebApi.Models
{
    public class Campus
    {
        public int Id { get; set; }

        [Required] public string Name { get; set; }
    }
}