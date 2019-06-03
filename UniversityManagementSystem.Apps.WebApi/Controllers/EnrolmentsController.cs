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
    public class EnrolmentsController : ControllerBase<Enrolment, Models.Enrolment>
    {
        public EnrolmentsController(IEnrolmentService enrolmentService, IMapper mapper) : base(enrolmentService)
        {
            EnrolmentService = enrolmentService;
            Mapper = mapper;
        }

        protected override IMapper Mapper { get; }

        private IEnrolmentService EnrolmentService { get; }

        #region /Enrolments

        [HttpGet]
        public override async Task<ActionResult<IEnumerable<Models.Enrolment>>> GetAsync()
        {
            return await base.GetAsync();
        }

        [HttpGet("{enrolmentId}", Name = "GetEnrolmentByEnrolmentId")]
        public override async Task<ActionResult<Models.Enrolment>> GetAsync(int enrolmentId)
        {
            return await base.GetAsync(enrolmentId);
        }

        [HttpPost]
        public override async Task<ActionResult> PostAsync([FromBody] Models.Enrolment model)
        {
            if (!ModelState.IsValid) return BadRequest();

            var entity = Mapper.Map<Enrolment>(model);

            await EnrolmentService.AddAsync(entity);

            return CreatedAtRoute(
                "GetEnrolmentByEnrolmentId",
                new {enrolmentId = entity.Id},
                Mapper.Map<Models.Enrolment>(entity)
            );
        }

        [HttpPut("{enrolmentId}")]
        public override async Task<ActionResult> PutAsync(int enrolmentId, [FromBody] Models.Enrolment model)
        {
            if (enrolmentId != model.Id) return BadRequest();

            return await base.PutAsync(enrolmentId, model);
        }

        [HttpDelete("{enrolmentId}")]
        public override async Task<ActionResult> DeleteAsync(int enrolmentId)
        {
            return await base.DeleteAsync(enrolmentId);
        }

        #endregion
    }
}