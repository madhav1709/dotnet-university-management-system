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
    public class LecturesController : ControllerBase<Lecture, LectureViewModel>
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
        public override async Task<ActionResult<IEnumerable<LectureViewModel>>> GetAsync()
        {
            return await base.GetAsync();
        }

        [HttpGet("{lectureId}", Name = "GetLectureByLectureId")]
        public override async Task<ActionResult<LectureViewModel>> GetAsync(int lectureId)
        {
            return await base.GetAsync(lectureId);
        }

        [HttpPost]
        public override async Task<ActionResult> PostAsync([FromBody] LectureViewModel lectureViewModel)
        {
            if (!ModelState.IsValid) return BadRequest();

            var lecture = Mapper.Map<Lecture>(lectureViewModel);

            await LectureService.AddAsync(lecture);

            return CreatedAtRoute(
                "GetLectureByLectureId",
                new {lectureId = lecture.Id},
                Mapper.Map<LectureViewModel>(lecture)
            );
        }

        [HttpPut("{lectureId}")]
        public override async Task<ActionResult> PutAsync(int lectureId, [FromBody] LectureViewModel lectureViewModel)
        {
            if (lectureId != lectureViewModel.Id) return BadRequest();

            return await base.PutAsync(lectureId, lectureViewModel);
        }

        [HttpDelete("{lectureId}")]
        public override async Task<ActionResult> DeleteAsync(int lectureId)
        {
            return await base.DeleteAsync(lectureId);
        }

        #endregion
    }
}