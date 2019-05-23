using System.ComponentModel.DataAnnotations;

namespace UniversityManagementSystem.Apps.WebApi.ViewModels
{
    public class CampusViewModel
    {
        public int Id { get; set; }

        [Required] public string Name { get; set; }
    }
}