using System.ComponentModel.DataAnnotations;

namespace UniversityManagementSystem.Apps.WebApi.Models
{
    public class Refectory
    {
        public int Id { get; set; }

        [Required] public string Name { get; set; }

        [Required] public Building Building { get; set; }
    }
}