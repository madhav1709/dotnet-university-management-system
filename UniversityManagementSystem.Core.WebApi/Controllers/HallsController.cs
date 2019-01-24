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
    public class HallsController : ControllerBase<Hall, HallViewModel>
    {
        public HallsController(IHallService hallService, IMapper mapper) : base(hallService)
        {
            HallService = hallService;
            Mapper = mapper;
        }

        protected override IMapper Mapper { get; }

        private IHallService HallService { get; }

        #region /Halls

        [HttpGet]
        public override async Task<ActionResult<IEnumerable<HallViewModel>>> GetAsync()
        {
            return await base.GetAsync();
        }

        [HttpGet("{hallId}", Name = "GetHallByHallId")]
        public override async Task<ActionResult<HallViewModel>> GetAsync(int hallId)
        {
            return await base.GetAsync(hallId);
        }

        [HttpPost]
        public override async Task<ActionResult> PostAsync([FromBody] HallViewModel hallViewModel)
        {
            if (!ModelState.IsValid) return BadRequest();

            var hall = Mapper.Map<Hall>(hallViewModel);

            await HallService.AddAsync(hall);

            return CreatedAtRoute(
                "GetHallByHallId",
                new {hallId = hall.Id},
                Mapper.Map<HallViewModel>(hall)
            );
        }

        [HttpPut("{hallId}")]
        public override async Task<ActionResult> PutAsync(int hallId, [FromBody] HallViewModel hallViewModel)
        {
            if (hallId != hallViewModel.Id) return BadRequest();

            return await base.PutAsync(hallId, hallViewModel);
        }

        [HttpDelete("{hallId}")]
        public override async Task<ActionResult> DeleteAsync(int hallId)
        {
            return await base.DeleteAsync(hallId);
        }

        #endregion
    }
}