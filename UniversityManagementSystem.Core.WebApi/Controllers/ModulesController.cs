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
    public class ModulesController : ControllerBase<Module, ModuleViewModel>
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
        public override async Task<ActionResult<IEnumerable<ModuleViewModel>>> GetAsync()
        {
            return await base.GetAsync();
        }

        [HttpGet("{moduleId}", Name = "GetModuleByModuleId")]
        public override async Task<ActionResult<ModuleViewModel>> GetAsync(int moduleId)
        {
            return await base.GetAsync(moduleId);
        }

        [HttpPost]
        public override async Task<ActionResult> PostAsync([FromBody] ModuleViewModel moduleViewModel)
        {
            if (!ModelState.IsValid) return BadRequest();

            var module = Mapper.Map<Module>(moduleViewModel);

            await ModuleService.AddAsync(module);

            return CreatedAtRoute(
                "GetModuleByModuleId",
                new {moduleId = module.Id},
                Mapper.Map<ModuleViewModel>(module)
            );
        }

        [HttpPut("{moduleId}")]
        public override async Task<ActionResult> PutAsync(int moduleId, [FromBody] ModuleViewModel moduleViewModel)
        {
            if (moduleId != moduleViewModel.Id) return BadRequest();

            return await base.PutAsync(moduleId, moduleViewModel);
        }

        [HttpDelete("{moduleId}")]
        public override async Task<ActionResult> DeleteAsync(int moduleId)
        {
            return await base.DeleteAsync(moduleId);
        }

        #endregion
    }
}