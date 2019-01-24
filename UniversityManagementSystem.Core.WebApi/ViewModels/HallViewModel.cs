using System.ComponentModel.DataAnnotations;

namespace UniversityManagementSystem.Core.WebApi.ViewModels
{
    public class HallViewModel
    {
        public int Id { get; set; }

        [Required] public string Name { get; set; }

        [Required] public CampusViewModel Campus { get; set; }
    }
}