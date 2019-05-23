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
    public class RoomsController : ControllerBase<Room, RoomViewModel>
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
        public override async Task<ActionResult<IEnumerable<RoomViewModel>>> GetAsync()
        {
            return await base.GetAsync();
        }

        [HttpGet("{roomId}", Name = "GetRoomByRoomId")]
        public override async Task<ActionResult<RoomViewModel>> GetAsync(int roomId)
        {
            return await base.GetAsync(roomId);
        }

        [HttpPost]
        public override async Task<ActionResult> PostAsync([FromBody] RoomViewModel roomViewModel)
        {
            if (!ModelState.IsValid) return BadRequest();

            var room = Mapper.Map<Room>(roomViewModel);

            await RoomService.AddAsync(room);

            return CreatedAtRoute(
                "GetRoomByRoomId",
                new {roomId = room.Id},
                Mapper.Map<RoomViewModel>(room)
            );
        }

        [HttpPut("{roomId}")]
        public override async Task<ActionResult> PutAsync(int roomId, [FromBody] RoomViewModel roomViewModel)
        {
            if (roomId != roomViewModel.Id) return BadRequest();

            return await base.PutAsync(roomId, roomViewModel);
        }

        [HttpDelete("{roomId}")]
        public override async Task<ActionResult> DeleteAsync(int roomId)
        {
            return await base.DeleteAsync(roomId);
        }

        #endregion
    }
}