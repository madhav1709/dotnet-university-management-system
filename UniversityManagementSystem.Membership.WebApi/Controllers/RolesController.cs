using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UniversityManagementSystem.Exceptions;
using UniversityManagementSystem.Membership.Services;
using UniversityManagementSystem.Membership.WebApi.ViewModels;

namespace UniversityManagementSystem.Membership.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiConventionType(typeof(DefaultApiConventions))]
    [Authorize]
    public class RolesController : ControllerBase
    {
        public RolesController(IMapper mapper, IRoleService roleService)
        {
            Mapper = mapper;
            RoleService = roleService;
        }

        private IMapper Mapper { get; }

        private IRoleService RoleService { get; }

        #region /Roles

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RoleViewModel>>> GetAsync()
        {
            var roles = await RoleService.QueryAsync();

            var roleViewModels = Mapper.Map<List<RoleViewModel>>(roles);

            return Ok(roleViewModels);
        }

        [HttpGet("{roleName}", Name = "GetRoleByRoleName")]
        public async Task<ActionResult<RoleViewModel>> GetAsync(string roleName)
        {
            var role = await RoleService.QueryAsync(roleName);

            if (role == null) return NotFound();

            var roleViewModel = Mapper.Map<RoleViewModel>(role);

            return Ok(roleViewModel);
        }

        [HttpPost]
        public async Task<ActionResult> PostAsync([FromBody] RoleViewModel roleViewModel)
        {
            if (!ModelState.IsValid) return BadRequest();

            var role = Mapper.Map<IdentityRole>(roleViewModel);

            await RoleService.AddAsync(role);

            return CreatedAtRoute("GetRoleByRoleName", new {roleName = role.Name}, Mapper.Map<RoleViewModel>(role));
        }

        [HttpPut("{roleName}")]
        public async Task<ActionResult> PutAsync(string roleName, [FromBody] RoleViewModel roleViewModel)
        {
            if (!ModelState.IsValid) return BadRequest();

            if (roleName != roleViewModel.Name) return BadRequest();

            var role = Mapper.Map<IdentityRole>(roleViewModel);

            await RoleService.UpdateAsync(role);

            return NoContent();
        }

        [HttpDelete("{roleName}")]
        public async Task<ActionResult> DeleteAsync(string roleName)
        {
            try
            {
                await RoleService.RemoveAsync(roleName);
            }
            catch (EntityNotFoundException)
            {
                return NotFound();
            }

            return NoContent();
        }

        #endregion

        #region /Roles/{roleName}/Claims

        [HttpGet("{roleName}/Claims")]
        public async Task<ActionResult<IEnumerable<ClaimViewModel>>> GetClaimsAsync(string roleName)
        {
            try
            {
                var claims = await RoleService.QueryClaimsAsync(roleName);

                var claimViewModels = Mapper.Map<IEnumerable<ClaimViewModel>>(claims);

                return Ok(claimViewModels);
            }
            catch (EntityNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpPost("{roleName}/Claims")]
        public async Task<ActionResult> PostClaimAsync(string roleName, [FromBody] ClaimViewModel claimViewModel)
        {
            if (!ModelState.IsValid) return BadRequest();

            var claim = Mapper.Map<Claim>(claimViewModel);

            try
            {
                await RoleService.AddClaimAsync(roleName, claim);
            }
            catch (EntityNotFoundException)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{roleName}/Claims/{claimType}")]
        public async Task<ActionResult> DeleteClaimAsync(string roleName, string claimType)
        {
            try
            {
                await RoleService.RemoveClaimAsync(roleName, claimType);
            }
            catch (EntityNotFoundException)
            {
                return NotFound();
            }

            return NoContent();
        }

        #endregion
    }
}