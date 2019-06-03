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
    public class RoomsController : ControllerBase<Room, Models.Room>
    {
        public RoomsController(IRoomService roomService, IMapper mapper) : base(roomService)
        {
            RoomService = roomService;
            Mapper = mapper;
        }

        protected override IMapper Mapper { get; }

        private IRoomService RoomService { get; }

        #region /Rooms

        [HttpGet]
        public override async Task<ActionResult<IEnumerable<Models.Room>>> GetAsync()
        {
            return await base.GetAsync();
        }

        [HttpGet("{roomId}", Name = "GetRoomByRoomId")]
        public override async Task<ActionResult<Models.Room>> GetAsync(int roomId)
        {
            return await base.GetAsync(roomId);
        }

        [HttpPost]
        public override async Task<ActionResult> PostAsync([FromBody] Models.Room model)
        {
            if (!ModelState.IsValid) return BadRequest();

            var entity = Mapper.Map<Room>(model);

            await RoomService.AddAsync(entity);

            return CreatedAtRoute(
                "GetRoomByRoomId",
                new {roomId = entity.Id},
                Mapper.Map<Models.Room>(entity)
            );
        }

        [HttpPut("{roomId}")]
        public override async Task<ActionResult> PutAsync(int roomId, [FromBody] Models.Room model)
        {
            if (roomId != model.Id) return BadRequest();

            return await base.PutAsync(roomId, model);
        }

        [HttpDelete("{roomId}")]
        public override async Task<ActionResult> DeleteAsync(int roomId)
        {
            return await base.DeleteAsync(roomId);
        }

        #endregion
    }
}