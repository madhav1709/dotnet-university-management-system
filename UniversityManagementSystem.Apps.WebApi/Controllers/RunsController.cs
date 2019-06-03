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
    public class RunsController : ControllerBase<Run, Models.Run>
    {
        public RunsController(IRunService runService, IMapper mapper) : base(runService)
        {
            RunService = runService;
            Mapper = mapper;
        }

        protected override IMapper Mapper { get; }

        private IRunService RunService { get; }

        #region /Runs

        [HttpGet]
        public override async Task<ActionResult<IEnumerable<Models.Run>>> GetAsync()
        {
            return await base.GetAsync();
        }

        [HttpGet("{runId}", Name = "GetRunByRunId")]
        public override async Task<ActionResult<Models.Run>> GetAsync(int runId)
        {
            return await base.GetAsync(runId);
        }

        [HttpPost]
        public override async Task<ActionResult> PostAsync([FromBody] Models.Run model)
        {
            if (!ModelState.IsValid) return BadRequest();

            var entity = Mapper.Map<Run>(model);

            await RunService.AddAsync(entity);

            return CreatedAtRoute(
                "GetRunByRunId",
                new {runId = entity.Id},
                Mapper.Map<Models.Run>(entity)
            );
        }

        [HttpPut("{runId}")]
        public override async Task<ActionResult> PutAsync(int runId, [FromBody] Models.Run model)
        {
            if (runId != model.Id) return BadRequest();

            return await base.PutAsync(runId, model);
        }

        [HttpDelete("{runId}")]
        public override async Task<ActionResult> DeleteAsync(int runId)
        {
            return await base.DeleteAsync(runId);
        }

        #endregion
    }
}