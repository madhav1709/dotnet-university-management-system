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
    public class SchoolsController : ControllerBase<School, Models.School>
    {
        public SchoolsController(ISchoolService schoolService, IMapper mapper) : base(schoolService)
        {
            SchoolService = schoolService;
            Mapper = mapper;
        }

        protected override IMapper Mapper { get; }

        private ISchoolService SchoolService { get; }

        #region /Schools

        [HttpGet]
        public override async Task<ActionResult<IEnumerable<Models.School>>> GetAsync()
        {
            return await base.GetAsync();
        }

        [HttpGet("{schoolId}", Name = "GetSchoolBySchoolId")]
        public override async Task<ActionResult<Models.School>> GetAsync(int schoolId)
        {
            return await base.GetAsync(schoolId);
        }

        [HttpPost]
        public override async Task<ActionResult> PostAsync([FromBody] Models.School model)
        {
            if (!ModelState.IsValid) return BadRequest();

            var entity = Mapper.Map<School>(model);

            await SchoolService.AddAsync(entity);

            return CreatedAtRoute(
                "GetSchoolBySchoolId",
                new {schoolId = entity.Id},
                Mapper.Map<Models.School>(entity)
            );
        }

        [HttpPut("{schoolId}")]
        public override async Task<ActionResult> PutAsync(int schoolId, [FromBody] Models.School model)
        {
            if (schoolId != model.Id) return BadRequest();

            return await base.PutAsync(schoolId, model);
        }

        [HttpDelete("{schoolId}")]
        public override async Task<ActionResult> DeleteAsync(int schoolId)
        {
            return await base.DeleteAsync(schoolId);
        }

        #endregion
    }
}