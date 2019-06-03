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
    public class LecturesController : ControllerBase<Lecture, Models.Lecture>
    {
        public LecturesController(ILectureService lectureService, IMapper mapper) : base(lectureService)
        {
            LectureService = lectureService;
            Mapper = mapper;
        }

        protected override IMapper Mapper { get; }

        private ILectureService LectureService { get; }

        #region /Lectures

        [HttpGet]
        public override async Task<ActionResult<IEnumerable<Models.Lecture>>> GetAsync()
        {
            return await base.GetAsync();
        }

        [HttpGet("{lectureId}", Name = "GetLectureByLectureId")]
        public override async Task<ActionResult<Models.Lecture>> GetAsync(int lectureId)
        {
            return await base.GetAsync(lectureId);
        }

        [HttpPost]
        public override async Task<ActionResult> PostAsync([FromBody] Models.Lecture model)
        {
            if (!ModelState.IsValid) return BadRequest();

            var entity = Mapper.Map<Lecture>(model);

            await LectureService.AddAsync(entity);

            return CreatedAtRoute(
                "GetLectureByLectureId",
                new {lectureId = entity.Id},
                Mapper.Map<Models.Lecture>(entity)
            );
        }

        [HttpPut("{lectureId}")]
        public override async Task<ActionResult> PutAsync(int lectureId, [FromBody] Models.Lecture model)
        {
            if (lectureId != model.Id) return BadRequest();

            return await base.PutAsync(lectureId, model);
        }

        [HttpDelete("{lectureId}")]
        public override async Task<ActionResult> DeleteAsync(int lectureId)
        {
            return await base.DeleteAsync(lectureId);
        }

        #endregion
    }
}