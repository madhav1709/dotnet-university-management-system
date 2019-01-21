using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UniversityManagementSystem.Exceptions;
using UniversityManagementSystem.Membership.Data.Entities;
using UniversityManagementSystem.Membership.Services;
using UniversityManagementSystem.Membership.WebApi.ViewModels;

namespace UniversityManagementSystem.Membership.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiConventionType(typeof(DefaultApiConventions))]
    [Authorize]
    public class UsersController : ControllerBase
    {
        public UsersController(IMapper mapper, IUserService userService)
        {
            Mapper = mapper;
            UserService = userService;
        }

        private IMapper Mapper { get; }

        private IUserService UserService { get; }

        #region /Users

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserViewModel>>> GetAsync()
        {
            var users = await UserService.QueryAsync();

            var userViewModels = Mapper.Map<IEnumerable<UserViewModel>>(users);

            return Ok(userViewModels);
        }

        [HttpGet("{userId}", Name = "GetUserByUserId")]
        public async Task<ActionResult<UserViewModel>> GetAsync(string userId)
        {
            var user = await UserService.QueryAsync(userId);

            if (user == null) return NotFound();

            var userViewModel = Mapper.Map<UserViewModel>(user);

            return Ok(userViewModel);
        }

        [HttpPost]
        public async Task<ActionResult> PostAsync([FromBody] UserViewModel userViewModel)
        {
            if (!ModelState.IsValid) return BadRequest();

            var user = Mapper.Map<ApplicationUser>(userViewModel);

            await UserService.AddAsync(user, userViewModel.Password);

            return CreatedAtRoute("GetUserByUserId", new {userId = user.Id}, Mapper.Map<UserViewModel>(user));
        }

        [HttpPut("{userId}")]
        public async Task<ActionResult> PutAsync(string userId, [FromBody] UserViewModel userViewModel)
        {
            if (!ModelState.IsValid) return BadRequest();

            if (userId != userViewModel.Id) return BadRequest();

            var user = Mapper.Map<ApplicationUser>(userViewModel);

            await UserService.UpdateAsync(user);

            return NoContent();
        }

        [HttpDelete("{userId}")]
        public async Task<ActionResult> DeleteAsync(string userId)
        {
            try
            {
                await UserService.RemoveAsync(userId);
            }
            catch (EntityNotFoundException)
            {
                return NotFound();
            }

            return NoContent();
        }

        #endregion

        #region /Users/{userId}/Claims

        [HttpGet("{userId}/Claims")]
        public async Task<ActionResult<IEnumerable<ClaimViewModel>>> GetClaimsAsync(string userId)
        {
            try
            {
                var claims = await UserService.QueryClaimsAsync(userId);

                var claimViewModels = Mapper.Map<IEnumerable<ClaimViewModel>>(claims);

                return Ok(claimViewModels);
            }
            catch (EntityNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpPost("{userId}/Claims")]
        public async Task<ActionResult> PostClaimAsync(string userId, [FromBody] ClaimViewModel claimViewModel)
        {
            if (!ModelState.IsValid) return BadRequest();

            var claim = Mapper.Map<Claim>(claimViewModel);

            try
            {
                await UserService.AddClaimAsync(userId, claim);
            }
            catch (EntityNotFoundException)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{userId}/Claims/{claimType}")]
        public async Task<ActionResult> DeleteClaimAsync(string userId, string claimType)
        {
            try
            {
                await UserService.RemoveClaimAsync(userId, claimType);
            }
            catch (EntityNotFoundException)
            {
                return NotFound();
            }

            return NoContent();
        }

        #endregion

        #region /Users/{userId}/Roles

        [HttpGet("{userId}/Roles")]
        public async Task<ActionResult<IEnumerable<string>>> GetRolesAsync(string userId)
        {
            try
            {
                var roles = await UserService.QueryRolesAsync(userId);

                return Ok(roles);
            }
            catch (EntityNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpPost("{userId}/Roles")]
        public async Task<ActionResult> PostToRoleAsync(string userId, [FromBody] string roleName)
        {
            try
            {
                await UserService.AddToRoleAsync(userId, roleName);
            }
            catch (EntityNotFoundException)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{userId}/Roles/{roleName}")]
        public async Task<ActionResult> DeleteFromRoleAsync(string userId, string roleName)
        {
            try
            {
                await UserService.RemoveFromRoleAsync(userId, roleName);
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