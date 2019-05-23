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
    public class GraduationsController : ControllerBase<Graduation, GraduationViewModel>
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
        public override async Task<ActionResult<IEnumerable<GraduationViewModel>>> GetAsync()
        {
            return await base.GetAsync();
        }

        [HttpGet("{graduationId}", Name = "GetGraduationByGraduationId")]
        public override async Task<ActionResult<GraduationViewModel>> GetAsync(int graduationId)
        {
            return await base.GetAsync(graduationId);
        }

        [HttpPost]
        public override async Task<ActionResult> PostAsync([FromBody] GraduationViewModel graduationViewModel)
        {
            if (!ModelState.IsValid) return BadRequest();

            var graduation = Mapper.Map<Graduation>(graduationViewModel);

            await GraduationService.AddAsync(graduation);

            return CreatedAtRoute(
                "GetGraduationByGraduationId",
                new {graduationId = graduation.Id},
                Mapper.Map<GraduationViewModel>(graduation)
            );
        }

        [HttpPut("{graduationId}")]
        public override async Task<ActionResult> PutAsync(int graduationId, [FromBody] GraduationViewModel graduationViewModel)
        {
            if (graduationId != graduationViewModel.Id) return BadRequest();

            return await base.PutAsync(graduationId, graduationViewModel);
        }

        [HttpDelete("{graduationId}")]
        public override async Task<ActionResult> DeleteAsync(int graduationId)
        {
            return await base.DeleteAsync(graduationId);
        }

        #endregion
    }
}