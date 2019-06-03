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
    public class AssignmentsController : ControllerBase<Assignment, Models.Assignment>
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
        public override async Task<ActionResult<IEnumerable<Models.Assignment>>> GetAsync()
        {
            return await base.GetAsync();
        }

        [HttpGet("{assignmentId}", Name = "GetAssignmentByAssignmentId")]
        public override async Task<ActionResult<Models.Assignment>> GetAsync(int assignmentId)
        {
            return await base.GetAsync(assignmentId);
        }

        [HttpPost]
        public override async Task<ActionResult> PostAsync([FromBody] Models.Assignment model)
        {
            if (!ModelState.IsValid) return BadRequest();

            var entity = Mapper.Map<Assignment>(model);

            await AssignmentService.AddAsync(entity);

            return CreatedAtRoute(
                "GetAssignmentByAssignmentId",
                new {assignmentId = entity.Id},
                Mapper.Map<Models.Assignment>(entity)
            );
        }

        [HttpPut("{assignmentId}")]
        public override async Task<ActionResult> PutAsync(int assignmentId, [FromBody] Models.Assignment model)
        {
            if (assignmentId != model.Id) return BadRequest();

            return await base.PutAsync(assignmentId, model);
        }

        [HttpDelete("{assignmentId}")]
        public override async Task<ActionResult> DeleteAsync(int assignmentId)
        {
            return await base.DeleteAsync(assignmentId);
        }

        #endregion
    }
}