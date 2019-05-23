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
    public class CoursesController : ControllerBase<Course, CourseViewModel>
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
        public override async Task<ActionResult<IEnumerable<CourseViewModel>>> GetAsync()
        {
            return await base.GetAsync();
        }

        [HttpGet("{courseId}", Name = "GetCourseByCourseId")]
        public override async Task<ActionResult<CourseViewModel>> GetAsync(int courseId)
        {
            return await base.GetAsync(courseId);
        }

        [HttpPost]
        public override async Task<ActionResult> PostAsync([FromBody] CourseViewModel courseViewModel)
        {
            if (!ModelState.IsValid) return BadRequest();

            var course = Mapper.Map<Course>(courseViewModel);

            await CourseService.AddAsync(course);

            return CreatedAtRoute(
                "GetCourseByCourseId",
                new {courseId = course.Id},
                Mapper.Map<CourseViewModel>(course)
            );
        }

        [HttpPut("{courseId}")]
        public override async Task<ActionResult> PutAsync(int courseId, [FromBody] CourseViewModel courseViewModel)
        {
            if (courseId != courseViewModel.Id) return BadRequest();

            return await base.PutAsync(courseId, courseViewModel);
        }

        [HttpDelete("{courseId}")]
        public override async Task<ActionResult> DeleteAsync(int courseId)
        {
            return await base.DeleteAsync(courseId);
        }

        #endregion
    }
}