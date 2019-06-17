using System.Threading.Tasks;
using UniversityManagementSystem.Apps.Blazor.Models;

namespace UniversityManagementSystem.Apps.Blazor.Services
{
    public interface IAuthenticationService
    {
        Task<User> GetUserAsync();

        Task LoginAsync(string callback = "redirect");

        Task LogoutAsync(string callback = "redirect");
    }
}