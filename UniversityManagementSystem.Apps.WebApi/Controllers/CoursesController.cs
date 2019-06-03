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
    public class CoursesController : ControllerBase<Course, Models.Course>
    {
        public CoursesController(ICourseService courseService, IMapper mapper) : base(courseService)
        {
            CourseService = courseService;
            Mapper = mapper;
        }

        protected override IMapper Mapper { get; }

        private ICourseService CourseService { get; }

        #region /Courses

        [HttpGet]
        public override async Task<ActionResult<IEnumerable<Models.Course>>> GetAsync()
        {
            return await base.GetAsync();
        }

        [HttpGet("{courseId}", Name = "GetCourseByCourseId")]
        public override async Task<ActionResult<Models.Course>> GetAsync(int courseId)
        {
            return await base.GetAsync(courseId);
        }

        [HttpPost]
        public override async Task<ActionResult> PostAsync([FromBody] Models.Course model)
        {
            if (!ModelState.IsValid) return BadRequest();

            var entity = Mapper.Map<Course>(model);

            await CourseService.AddAsync(entity);

            return CreatedAtRoute(
                "GetCourseByCourseId",
                new {courseId = entity.Id},
                Mapper.Map<Models.Course>(entity)
            );
        }

        [HttpPut("{courseId}")]
        public override async Task<ActionResult> PutAsync(int courseId, [FromBody] Models.Course model)
        {
            if (courseId != model.Id) return BadRequest();

            return await base.PutAsync(courseId, model);
        }

        [HttpDelete("{courseId}")]
        public override async Task<ActionResult> DeleteAsync(int courseId)
        {
            return await base.DeleteAsync(courseId);
        }

        #endregion
    }
}