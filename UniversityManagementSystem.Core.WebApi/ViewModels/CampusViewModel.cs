using System.ComponentModel.DataAnnotations;

namespace UniversityManagementSystem.Core.WebApi.ViewModels
{
    public class CampusViewModel
    {
        public int Id { get; set; }

        [Required] public string Name { get; set; }
    }
}