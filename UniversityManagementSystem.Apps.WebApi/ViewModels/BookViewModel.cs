using System.ComponentModel.DataAnnotations;

namespace UniversityManagementSystem.Apps.WebApi.ViewModels
{
    public class BookViewModel
    {
        public int Id { get; set; }

        [Required] public string Name { get; set; }

        [Required] public string Author { get; set; }
    }
}