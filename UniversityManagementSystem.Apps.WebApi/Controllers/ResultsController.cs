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
    public class ResultsController : ControllerBase<Result, Models.Result>
    {
        public ResultsController(IResultService resultService, IMapper mapper) : base(resultService)
        {
            ResultService = resultService;
            Mapper = mapper;
        }

        protected override IMapper Mapper { get; }

        private IResultService ResultService { get; }

        #region /Results

        [HttpGet]
        public override async Task<ActionResult<IEnumerable<Models.Result>>> GetAsync()
        {
            return await base.GetAsync();
        }

        [HttpGet("{resultId}", Name = "GetResultByResultId")]
        public override async Task<ActionResult<Models.Result>> GetAsync(int resultId)
        {
            return await base.GetAsync(resultId);
        }

        [HttpPost]
        public override async Task<ActionResult> PostAsync([FromBody] Models.Result model)
        {
            if (!ModelState.IsValid) return BadRequest();

            var entity = Mapper.Map<Result>(model);

            await ResultService.AddAsync(entity);

            return CreatedAtRoute(
                "GetResultByResultId",
                new {resultId = entity.Id},
                Mapper.Map<Models.Result>(entity)
            );
        }

        [HttpPut("{resultId}")]
        public override async Task<ActionResult> PutAsync(int resultId, [FromBody] Models.Result model)
        {
            if (resultId != model.Id) return BadRequest();

            return await base.PutAsync(resultId, model);
        }

        [HttpDelete("{resultId}")]
        public override async Task<ActionResult> DeleteAsync(int resultId)
        {
            return await base.DeleteAsync(resultId);
        }

        #endregion
    }
}