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
    public class ModulesController : ControllerBase<Module, Models.Module>
    {
        public ModulesController(IModuleService moduleService, IMapper mapper) : base(moduleService)
        {
            ModuleService = moduleService;
            Mapper = mapper;
        }

        protected override IMapper Mapper { get; }

        private IModuleService ModuleService { get; }

        #region /Modules

        [HttpGet]
        public override async Task<ActionResult<IEnumerable<Models.Module>>> GetAsync()
        {
            return await base.GetAsync();
        }

        [HttpGet("{moduleId}", Name = "GetModuleByModuleId")]
        public override async Task<ActionResult<Models.Module>> GetAsync(int moduleId)
        {
            return await base.GetAsync(moduleId);
        }

        [HttpPost]
        public override async Task<ActionResult> PostAsync([FromBody] Models.Module model)
        {
            if (!ModelState.IsValid) return BadRequest();

            var entity = Mapper.Map<Module>(model);

            await ModuleService.AddAsync(entity);

            return CreatedAtRoute(
                "GetModuleByModuleId",
                new {moduleId = entity.Id},
                Mapper.Map<Models.Module>(entity)
            );
        }

        [HttpPut("{moduleId}")]
        public override async Task<ActionResult> PutAsync(int moduleId, [FromBody] Models.Module model)
        {
            if (moduleId != model.Id) return BadRequest();

            return await base.PutAsync(moduleId, model);
        }

        [HttpDelete("{moduleId}")]
        public override async Task<ActionResult> DeleteAsync(int moduleId)
        {
            return await base.DeleteAsync(moduleId);
        }

        #endregion
    }
}