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
    public class RentalsController : ControllerBase<Rental, Models.Rental>
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
        public override async Task<ActionResult<IEnumerable<Models.Rental>>> GetAsync()
        {
            return await base.GetAsync();
        }

        [HttpGet("{rentalId}", Name = "GetRentalByRentalId")]
        public override async Task<ActionResult<Models.Rental>> GetAsync(int rentalId)
        {
            return await base.GetAsync(rentalId);
        }

        [HttpPost]
        public override async Task<ActionResult> PostAsync([FromBody] Models.Rental model)
        {
            if (!ModelState.IsValid) return BadRequest();

            var entity = Mapper.Map<Rental>(model);

            await RentalService.AddAsync(entity);

            return CreatedAtRoute(
                "GetRentalByRentalId",
                new {rentalId = entity.Id},
                Mapper.Map<Models.Rental>(entity)
            );
        }

        [HttpPut("{rentalId}")]
        public override async Task<ActionResult> PutAsync(int rentalId, [FromBody] Models.Rental model)
        {
            if (rentalId != model.Id) return BadRequest();

            return await base.PutAsync(rentalId, model);
        }

        [HttpDelete("{rentalId}")]
        public override async Task<ActionResult> DeleteAsync(int rentalId)
        {
            return await base.DeleteAsync(rentalId);
        }

        #endregion
    }
}