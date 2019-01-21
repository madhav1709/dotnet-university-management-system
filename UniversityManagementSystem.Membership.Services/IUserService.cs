using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using UniversityManagementSystem.Membership.Data.Entities;

namespace UniversityManagementSystem.Membership.Services
{
    public interface IUserService
    {
        Task AddAsync(ApplicationUser user, string password);

        Task AddClaimAsync(string userId, Claim claim);
        Task AddClaimAsync(ApplicationUser user, Claim claim);

        Task AddToRoleAsync(string userId, string roleName);
        Task AddToRoleAsync(ApplicationUser user, string roleName);

        Task<IEnumerable<ApplicationUser>> QueryAsync();
        Task<ApplicationUser> QueryAsync(string userId);

        Task<IEnumerable<Claim>> QueryClaimsAsync(string userId);
        Task<IEnumerable<Claim>> QueryClaimsAsync(ApplicationUser user);

        Task<IEnumerable<string>> QueryRolesAsync(string userId);
        Task<IEnumerable<string>> QueryRolesAsync(ApplicationUser user);

        Task RemoveAsync(string userId);

        Task RemoveClaimAsync(string userId, string claimType);
        Task RemoveClaimAsync(ApplicationUser user, string claimType);
        Task RemoveClaimAsync(ApplicationUser user, Claim claim);

        Task RemoveFromRoleAsync(string userId, string roleName);
        Task RemoveFromRoleAsync(ApplicationUser user, string roleName);

        Task UpdateAsync(ApplicationUser user);
    }
}