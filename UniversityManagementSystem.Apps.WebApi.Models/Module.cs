using System.ComponentModel.DataAnnotations;

namespace UniversityManagementSystem.Apps.WebApi.Models
{
    public class Module
    {
        public int Id { get; set; }

        [Required] public string Code { get; set; }

        [Required] public string Title { get; set; }
    }
}