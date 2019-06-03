using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UniversityManagementSystem.Data.Entities;
using UniversityManagementSystem.Services;

namespace UniversityManagementSystem.Apps.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiConventionType(typeof(DefaultApiConventions))]
    [Authorize]
    public class CampusesController : ControllerBase<Campus, Models.Campus>
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
        public override async Task<ActionResult<IEnumerable<Models.Campus>>> GetAsync()
        {
            return await base.GetAsync();
        }

        [HttpGet("{campusId}", Name = "GetCampusByCampusId")]
        public override async Task<ActionResult<Models.Campus>> GetAsync(int campusId)
        {
            return await base.GetAsync(campusId);
        }

        [HttpPost]
        public override async Task<ActionResult> PostAsync([FromBody] Models.Campus model)
        {
            if (!ModelState.IsValid) return BadRequest();

            var entity = Mapper.Map<Campus>(model);

            await CampusService.AddAsync(entity);

            return CreatedAtRoute(
                "GetCampusByCampusId",
                new {campusId = entity.Id},
                Mapper.Map<Models.Campus>(entity)
            );
        }

        [HttpPut("{campusId}")]
        public override async Task<ActionResult> PutAsync(int campusId, [FromBody] Models.Campus model)
        {
            if (campusId != model.Id) return BadRequest();

            return await base.PutAsync(campusId, model);
        }

        [HttpDelete("{campusId}")]
        public override async Task<ActionResult> DeleteAsync(int campusId)
        {
            return await base.DeleteAsync(campusId);
        }

        #endregion
    }
}