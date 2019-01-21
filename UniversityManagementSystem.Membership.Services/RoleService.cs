using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using UniversityManagementSystem.Exceptions;
using UniversityManagementSystem.Membership.Data.Contexts;

namespace UniversityManagementSystem.Membership.Services
{
    public class RoleService : IRoleService
    {
        public RoleService(ApplicationDbContext context, RoleManager<IdentityRole> roleManager)
        {
            Context = context;
            RoleManager = roleManager;
        }

        private ApplicationDbContext Context { get; }

        private RoleManager<IdentityRole> RoleManager { get; }

        public async Task AddAsync(IdentityRole role)
        {
            await RoleManager.CreateAsync(role);
        }

        public async Task AddClaimAsync(string roleName, Claim claim)
        {
            var role = await QueryAsync(roleName);

            if (role == null) throw new EntityNotFoundException();

            await AddClaimAsync(role, claim);
        }

        public async Task AddClaimAsync(IdentityRole role, Claim claim)
        {
            await RoleManager.AddClaimAsync(role, claim);
        }

        public async Task<List<IdentityRole>> QueryAsync()
        {
            return await RoleManager.Roles.ToListAsync();
        }

        public async Task<IdentityRole> QueryAsync(string roleName)
        {
            return await RoleManager.FindByNameAsync(roleName);
        }

        public async Task<IEnumerable<Claim>> QueryClaimsAsync(string roleName)
        {
            var role = await QueryAsync(roleName);

            if (role == null) throw new EntityNotFoundException();

            return await QueryClaimsAsync(role);
        }

        public async Task<IEnumerable<Claim>> QueryClaimsAsync(IdentityRole role)
        {
            return await RoleManager.GetClaimsAsync(role);
        }

        public async Task RemoveAsync(string roleName)
        {
            var role = await QueryAsync(roleName);

            if (role == null) throw new EntityNotFoundException();

            await RoleManager.DeleteAsync(role);
        }

        public async Task RemoveClaimAsync(string roleName, string claimType)
        {
            var role = await QueryAsync(roleName);

            if (role == null) throw new EntityNotFoundException();

            await RemoveClaimAsync(role, claimType);
        }

        public async Task RemoveClaimAsync(IdentityRole role, string claimType)
        {
            var claims = await Context.RoleClaims.Where(roleClaim => roleClaim.ClaimType == claimType).ToListAsync();

            if (claims.Count == 0) throw new EntityNotFoundException();

            foreach (var claim in claims) await RemoveClaimAsync(role, claim.ToClaim());
        }

        public async Task RemoveClaimAsync(IdentityRole role, Claim claim)
        {
            await RoleManager.RemoveClaimAsync(role, claim);
        }

        public async Task UpdateAsync(IdentityRole role)
        {
            await RoleManager.UpdateAsync(role);
        }
    }
}