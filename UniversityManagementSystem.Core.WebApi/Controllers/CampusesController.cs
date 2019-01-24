using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UniversityManagementSystem.Core.Data.Entities;
using UniversityManagementSystem.Core.Services;
using UniversityManagementSystem.Core.WebApi.ViewModels;

namespace UniversityManagementSystem.Core.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiConventionType(typeof(DefaultApiConventions))]
    [Authorize]
    public class CampusesController : ControllerBase<Campus, CampusViewModel>
    {
        public CampusesController(ICampusService campusService, IMapper mapper) : base(campusService)
        {
            CampusService = campusService;
            Mapper = mapper;
        }

        protected override IMapper Mapper { get; }

        private ICampusService CampusService { get; }

        #region /Campuses

        [HttpGet]
        public override async Task<ActionResult<IEnumerable<CampusViewModel>>> GetAsync()
        {
            return await base.GetAsync();
        }

        [HttpGet("{campusId}", Name = "GetCampusByCampusId")]
        public override async Task<ActionResult<CampusViewModel>> GetAsync(int campusId)
        {
            return await base.GetAsync(campusId);
        }

        [HttpPost]
        public override async Task<ActionResult> PostAsync([FromBody] CampusViewModel campusViewModel)
        {
            if (!ModelState.IsValid) return BadRequest();

            var campus = Mapper.Map<Campus>(campusViewModel);

            await CampusService.AddAsync(campus);

            return CreatedAtRoute(
                "GetCampusByCampusId",
                new {campusId = campus.Id},
                Mapper.Map<CampusViewModel>(campus)
            );
        }

        [HttpPut("{campusId}")]
        public override async Task<ActionResult> PutAsync(int campusId, [FromBody] CampusViewModel campusViewModel)
        {
            if (campusId != campusViewModel.Id) return BadRequest();

            return await base.PutAsync(campusId, campusViewModel);
        }

        [HttpDelete("{campusId}")]
        public override async Task<ActionResult> DeleteAsync(int campusId)
        {
            return await base.DeleteAsync(campusId);
        }

        #endregion
    }
}