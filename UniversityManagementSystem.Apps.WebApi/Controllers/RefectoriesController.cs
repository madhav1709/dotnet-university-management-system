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
    public class RefectoriesController : ControllerBase<Refectory, Models.Refectory>
    {
        public RefectoriesController(IRefectoryService refectoryService, IMapper mapper) : base(refectoryService)
        {
            RefectoryService = refectoryService;
            Mapper = mapper;
        }

        protected override IMapper Mapper { get; }

        private IRefectoryService RefectoryService { get; }

        #region /Refectories

        [HttpGet]
        public override async Task<ActionResult<IEnumerable<Models.Refectory>>> GetAsync()
        {
            return await base.GetAsync();
        }

        [HttpGet("{refectoryId}", Name = "GetRefectoryByRefectoryId")]
        public override async Task<ActionResult<Models.Refectory>> GetAsync(int refectoryId)
        {
            return await base.GetAsync(refectoryId);
        }

        [HttpPost]
        public override async Task<ActionResult> PostAsync([FromBody] Models.Refectory model)
        {
            if (!ModelState.IsValid) return BadRequest();

            var entity = Mapper.Map<Refectory>(model);

            await RefectoryService.AddAsync(entity);

            return CreatedAtRoute(
                "GetRefectoryByRefectoryId",
                new {refectoryId = entity.Id},
                Mapper.Map<Models.Refectory>(entity)
            );
        }

        [HttpPut("{refectoryId}")]
        public override async Task<ActionResult> PutAsync(int refectoryId, [FromBody] Models.Refectory model)
        {
            if (refectoryId != model.Id) return BadRequest();

            return await base.PutAsync(refectoryId, model);
        }

        [HttpDelete("{refectoryId}")]
        public override async Task<ActionResult> DeleteAsync(int refectoryId)
        {
            return await base.DeleteAsync(refectoryId);
        }

        #endregion
    }
}