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
    public class GraduationsController : ControllerBase<Graduation, Models.Graduation>
    {
        public GraduationsController(IGraduationService graduationService, IMapper mapper) : base(graduationService)
        {
            GraduationService = graduationService;
            Mapper = mapper;
        }

        protected override IMapper Mapper { get; }

        private IGraduationService GraduationService { get; }

        #region /Graduations

        [HttpGet]
        public override async Task<ActionResult<IEnumerable<Models.Graduation>>> GetAsync()
        {
            return await base.GetAsync();
        }

        [HttpGet("{graduationId}", Name = "GetGraduationByGraduationId")]
        public override async Task<ActionResult<Models.Graduation>> GetAsync(int graduationId)
        {
            return await base.GetAsync(graduationId);
        }

        [HttpPost]
        public override async Task<ActionResult> PostAsync([FromBody] Models.Graduation model)
        {
            if (!ModelState.IsValid) return BadRequest();

            var entity = Mapper.Map<Graduation>(model);

            await GraduationService.AddAsync(entity);

            return CreatedAtRoute(
                "GetGraduationByGraduationId",
                new {graduationId = entity.Id},
                Mapper.Map<Models.Graduation>(entity)
            );
        }

        [HttpPut("{graduationId}")]
        public override async Task<ActionResult> PutAsync(int graduationId, [FromBody] Models.Graduation model)
        {
            if (graduationId != model.Id) return BadRequest();

            return await base.PutAsync(graduationId, model);
        }

        [HttpDelete("{graduationId}")]
        public override async Task<ActionResult> DeleteAsync(int graduationId)
        {
            return await base.DeleteAsync(graduationId);
        }

        #endregion
    }
}