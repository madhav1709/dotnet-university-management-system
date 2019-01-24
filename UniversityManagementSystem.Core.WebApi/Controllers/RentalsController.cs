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
    public class RentalsController : ControllerBase<Rental, RentalViewModel>
    {
        public RentalsController(IRentalService rentalService, IMapper mapper) : base(rentalService)
        {
            RentalService = rentalService;
            Mapper = mapper;
        }

        protected override IMapper Mapper { get; }

        private IRentalService RentalService { get; }

        #region /Rentals

        [HttpGet]
        public override async Task<ActionResult<IEnumerable<RentalViewModel>>> GetAsync()
        {
            return await base.GetAsync();
        }

        [HttpGet("{rentalId}", Name = "GetRentalByRentalId")]
        public override async Task<ActionResult<RentalViewModel>> GetAsync(int rentalId)
        {
            return await base.GetAsync(rentalId);
        }

        [HttpPost]
        public override async Task<ActionResult> PostAsync([FromBody] RentalViewModel rentalViewModel)
        {
            if (!ModelState.IsValid) return BadRequest();

            var rental = Mapper.Map<Rental>(rentalViewModel);

            await RentalService.AddAsync(rental);

            return CreatedAtRoute(
                "GetRentalByRentalId",
                new {rentalId = rental.Id},
                Mapper.Map<RentalViewModel>(rental)
            );
        }

        [HttpPut("{rentalId}")]
        public override async Task<ActionResult> PutAsync(int rentalId, [FromBody] RentalViewModel rentalViewModel)
        {
            if (rentalId != rentalViewModel.Id) return BadRequest();

            return await base.PutAsync(rentalId, rentalViewModel);
        }

        [HttpDelete("{rentalId}")]
        public override async Task<ActionResult> DeleteAsync(int rentalId)
        {
            return await base.DeleteAsync(rentalId);
        }

        #endregion
    }
}