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
    public class AssignmentsController : ControllerBase<Assignment, AssignmentViewModel>
    {
        public AssignmentsController(IAssignmentService assignmentService, IMapper mapper) : base(assignmentService)
        {
            AssignmentService = assignmentService;
            Mapper = mapper;
        }

        protected override IMapper Mapper { get; }

        private IAssignmentService AssignmentService { get; }

        #region /Assignments

        [HttpGet]
        public override async Task<ActionResult<IEnumerable<AssignmentViewModel>>> GetAsync()
        {
            return await base.GetAsync();
        }

        [HttpGet("{assignmentId}", Name = "GetAssignmentByAssignmentId")]
        public override async Task<ActionResult<AssignmentViewModel>> GetAsync(int assignmentId)
        {
            return await base.GetAsync(assignmentId);
        }

        [HttpPost]
        public override async Task<ActionResult> PostAsync([FromBody] AssignmentViewModel assignmentViewModel)
        {
            if (!ModelState.IsValid) return BadRequest();

            var assignment = Mapper.Map<Assignment>(assignmentViewModel);

            await AssignmentService.AddAsync(assignment);

            return CreatedAtRoute(
                "GetAssignmentByAssignmentId",
                new {assignmentId = assignment.Id},
                Mapper.Map<AssignmentViewModel>(assignment)
            );
        }

        [HttpPut("{assignmentId}")]
        public override async Task<ActionResult> PutAsync(int assignmentId, [FromBody] AssignmentViewModel assignmentViewModel)
        {
            if (assignmentId != assignmentViewModel.Id) return BadRequest();

            return await base.PutAsync(assignmentId, assignmentViewModel);
        }

        [HttpDelete("{assignmentId}")]
        public override async Task<ActionResult> DeleteAsync(int assignmentId)
        {
            return await base.DeleteAsync(assignmentId);
        }

        #endregion
    }
}