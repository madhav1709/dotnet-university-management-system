using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace UniversityManagementSystem.Membership.Services
{
    public interface IRoleService
    {
        Task AddAsync(IdentityRole role);

        Task AddClaimAsync(string roleName, Claim claim);
        Task AddClaimAsync(IdentityRole role, Claim claim);

        Task<List<IdentityRole>> QueryAsync();
        Task<IdentityRole> QueryAsync(string roleName);

        Task<IEnumerable<Claim>> QueryClaimsAsync(string roleName);
        Task<IEnumerable<Claim>> QueryClaimsAsync(IdentityRole role);

        Task RemoveAsync(string roleName);

        Task RemoveClaimAsync(string roleName, string claimType);
        Task RemoveClaimAsync(IdentityRole role, string claimType);
        Task RemoveClaimAsync(IdentityRole role, Claim claim);

        Task UpdateAsync(IdentityRole role);
    }
}