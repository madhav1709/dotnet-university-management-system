using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UniversityManagementSystem.Apps.WebApi.ViewModels;
using UniversityManagementSystem.Data.Entities;
using UniversityManagementSystem.Services;

namespace UniversityManagementSystem.Apps.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiConventionType(typeof(DefaultApiConventions))]
    [Authorize]
    public class RunsController : ControllerBase<Run, RunViewModel>
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
        public override async Task<ActionResult<IEnumerable<RunViewModel>>> GetAsync()
        {
            return await base.GetAsync();
        }

        [HttpGet("{runId}", Name = "GetRunByRunId")]
        public override async Task<ActionResult<RunViewModel>> GetAsync(int runId)
        {
            return await base.GetAsync(runId);
        }

        [HttpPost]
        public override async Task<ActionResult> PostAsync([FromBody] RunViewModel runViewModel)
        {
            if (!ModelState.IsValid) return BadRequest();

            var run = Mapper.Map<Run>(runViewModel);

            await RunService.AddAsync(run);

            return CreatedAtRoute(
                "GetRunByRunId",
                new {runId = run.Id},
                Mapper.Map<RunViewModel>(run)
            );
        }

        [HttpPut("{runId}")]
        public override async Task<ActionResult> PutAsync(int runId, [FromBody] RunViewModel runViewModel)
        {
            if (runId != runViewModel.Id) return BadRequest();

            return await base.PutAsync(runId, runViewModel);
        }

        [HttpDelete("{runId}")]
        public override async Task<ActionResult> DeleteAsync(int runId)
        {
            return await base.DeleteAsync(runId);
        }

        #endregion
    }
}