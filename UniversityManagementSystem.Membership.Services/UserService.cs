using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using UniversityManagementSystem.Exceptions;
using UniversityManagementSystem.Membership.Data.Contexts;
using UniversityManagementSystem.Membership.Data.Entities;

namespace UniversityManagementSystem.Membership.Services
{
    public class UserService : IUserService
    {
        public UserService(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            Context = context;
            UserManager = userManager;
        }

        private ApplicationDbContext Context { get; }

        private UserManager<ApplicationUser> UserManager { get; }

        public async Task AddAsync(ApplicationUser user, string password)
        {
            await UserManager.CreateAsync(user, password);
        }

        public async Task AddClaimAsync(string userId, Claim claim)
        {
            var user = await QueryAsync(userId);

            if (user == null) throw new EntityNotFoundException();

            await AddClaimAsync(user, claim);
        }

        public async Task AddClaimAsync(ApplicationUser user, Claim claim)
        {
            await UserManager.AddClaimAsync(user, claim);
        }

        public async Task AddToRoleAsync(string userId, string roleName)
        {
            var user = await QueryAsync(userId);

            if (user == null) throw new EntityNotFoundException();

            await AddToRoleAsync(user, roleName);
        }

        public async Task AddToRoleAsync(ApplicationUser user, string roleName)
        {
            await UserManager.AddToRoleAsync(user, roleName);
        }

        public async Task<IEnumerable<ApplicationUser>> QueryAsync()
        {
            return await UserManager.Users.ToListAsync();
        }

        public async Task<ApplicationUser> QueryAsync(string userId)
        {
            return await UserManager.FindByIdAsync(userId);
        }

        public async Task<IEnumerable<Claim>> QueryClaimsAsync(string userId)
        {
            var user = await QueryAsync(userId);

            if (user == null) throw new EntityNotFoundException();

            return await QueryClaimsAsync(user);
        }

        public async Task<IEnumerable<Claim>> QueryClaimsAsync(ApplicationUser user)
        {
            return await UserManager.GetClaimsAsync(user);
        }

        public async Task<IEnumerable<string>> QueryRolesAsync(string userId)
        {
            var user = await QueryAsync(userId);

            if (user == null) throw new EntityNotFoundException();

            return await QueryRolesAsync(user);
        }

        public async Task<IEnumerable<string>> QueryRolesAsync(ApplicationUser user)
        {
            return await UserManager.GetRolesAsync(user);
        }

        public async Task RemoveAsync(string userId)
        {
            var user = await QueryAsync(userId);

            if (user == null) throw new EntityNotFoundException();

            await UserManager.DeleteAsync(user);
        }

        public async Task RemoveClaimAsync(string userId, string claimType)
        {
            var user = await QueryAsync(userId);

            if (user == null) throw new EntityNotFoundException();

            await RemoveClaimAsync(user, claimType);
        }

        public async Task RemoveClaimAsync(ApplicationUser user, string claimType)
        {
            var claims = await Context.UserClaims.Where(userClaim => userClaim.ClaimType == claimType).ToListAsync();

            if (claims.Count == 0) throw new EntityNotFoundException();

            foreach (var claim in claims) await RemoveClaimAsync(user, claim.ToClaim());
        }

        public async Task RemoveClaimAsync(ApplicationUser user, Claim claim)
        {
            await UserManager.RemoveClaimAsync(user, claim);
        }

        public async Task RemoveFromRoleAsync(string userId, string roleName)
        {
            var user = await QueryAsync(userId);

            if (user == null) throw new EntityNotFoundException();

            await RemoveFromRoleAsync(user, roleName);
        }

        public async Task RemoveFromRoleAsync(ApplicationUser user, string roleName)
        {
            await UserManager.RemoveFromRoleAsync(user, roleName);
        }

        public async Task UpdateAsync(ApplicationUser entity)
        {
            await UserManager.UpdateAsync(entity);
        }
    }
}