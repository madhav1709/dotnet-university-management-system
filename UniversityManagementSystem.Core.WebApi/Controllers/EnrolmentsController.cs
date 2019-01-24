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
    public class EnrolmentsController : ControllerBase<Enrolment, EnrolmentViewModel>
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
        public override async Task<ActionResult<IEnumerable<EnrolmentViewModel>>> GetAsync()
        {
            return await base.GetAsync();
        }

        [HttpGet("{enrolmentId}", Name = "GetEnrolmentByEnrolmentId")]
        public override async Task<ActionResult<EnrolmentViewModel>> GetAsync(int enrolmentId)
        {
            return await base.GetAsync(enrolmentId);
        }

        [HttpPost]
        public override async Task<ActionResult> PostAsync([FromBody] EnrolmentViewModel enrolmentViewModel)
        {
            if (!ModelState.IsValid) return BadRequest();

            var enrolment = Mapper.Map<Enrolment>(enrolmentViewModel);

            await EnrolmentService.AddAsync(enrolment);

            return CreatedAtRoute(
                "GetEnrolmentByEnrolmentId",
                new {enrolmentId = enrolment.Id},
                Mapper.Map<EnrolmentViewModel>(enrolment)
            );
        }

        [HttpPut("{enrolmentId}")]
        public override async Task<ActionResult> PutAsync(int enrolmentId, [FromBody] EnrolmentViewModel enrolmentViewModel)
        {
            if (enrolmentId != enrolmentViewModel.Id) return BadRequest();

            return await base.PutAsync(enrolmentId, enrolmentViewModel);
        }

        [HttpDelete("{enrolmentId}")]
        public override async Task<ActionResult> DeleteAsync(int enrolmentId)
        {
            return await base.DeleteAsync(enrolmentId);
        }

        #endregion
    }
}