using System.ComponentModel.DataAnnotations;

namespace UniversityManagementSystem.Membership.WebApi.ViewModels
{
    public class UserViewModel
    {
        public string Id { get; set; }

        [RegularExpression("^\\w*$")]
        [Required]
        public string UserName { get; set; }

        [Required] public string Password { get; set; }

        [EmailAddress] [Required] public string Email { get; set; }

        [Phone] [Required] public string PhoneNumber { get; set; }

        [Required] public string FirstName { get; set; }

        [Required] public string LastName { get; set; }
    }
}