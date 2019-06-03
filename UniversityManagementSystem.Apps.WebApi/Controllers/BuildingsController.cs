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
    public class BuildingsController : ControllerBase<Building, Models.Building>
    {
        public BuildingsController(IBuildingService buildingService, IMapper mapper) : base(buildingService)
        {
            BuildingService = buildingService;
            Mapper = mapper;
        }

        protected override IMapper Mapper { get; }

        private IBuildingService BuildingService { get; }

        #region /Buildings

        [HttpGet]
        public override async Task<ActionResult<IEnumerable<Models.Building>>> GetAsync()
        {
            return await base.GetAsync();
        }

        [HttpGet("{buildingId}", Name = "GetBuildingByBuildingId")]
        public override async Task<ActionResult<Models.Building>> GetAsync(int buildingId)
        {
            return await base.GetAsync(buildingId);
        }

        [HttpPost]
        public override async Task<ActionResult> PostAsync([FromBody] Models.Building model)
        {
            if (!ModelState.IsValid) return BadRequest();

            var entity = Mapper.Map<Building>(model);

            await BuildingService.AddAsync(entity);

            return CreatedAtRoute(
                "GetBuildingByBuildingId",
                new {buildingId = entity.Id},
                Mapper.Map<Models.Building>(entity)
            );
        }

        [HttpPut("{buildingId}")]
        public override async Task<ActionResult> PutAsync(int buildingId, [FromBody] Models.Building model)
        {
            if (buildingId != model.Id) return BadRequest();

            return await base.PutAsync(buildingId, model);
        }

        [HttpDelete("{buildingId}")]
        public override async Task<ActionResult> DeleteAsync(int buildingId)
        {
            return await base.DeleteAsync(buildingId);
        }

        #endregion
    }
}