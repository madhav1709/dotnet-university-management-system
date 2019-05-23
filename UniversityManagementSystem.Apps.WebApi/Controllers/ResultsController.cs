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
    public class ResultsController : ControllerBase<Result, ResultViewModel>
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
        public override async Task<ActionResult<IEnumerable<ResultViewModel>>> GetAsync()
        {
            return await base.GetAsync();
        }

        [HttpGet("{resultId}", Name = "GetResultByResultId")]
        public override async Task<ActionResult<ResultViewModel>> GetAsync(int resultId)
        {
            return await base.GetAsync(resultId);
        }

        [HttpPost]
        public override async Task<ActionResult> PostAsync([FromBody] ResultViewModel resultViewModel)
        {
            if (!ModelState.IsValid) return BadRequest();

            var result = Mapper.Map<Result>(resultViewModel);

            await ResultService.AddAsync(result);

            return CreatedAtRoute(
                "GetResultByResultId",
                new {resultId = result.Id},
                Mapper.Map<ResultViewModel>(result)
            );
        }

        [HttpPut("{resultId}")]
        public override async Task<ActionResult> PutAsync(int resultId, [FromBody] ResultViewModel resultViewModel)
        {
            if (resultId != resultViewModel.Id) return BadRequest();

            return await base.PutAsync(resultId, resultViewModel);
        }

        [HttpDelete("{resultId}")]
        public override async Task<ActionResult> DeleteAsync(int resultId)
        {
            return await base.DeleteAsync(resultId);
        }

        #endregion
    }
}