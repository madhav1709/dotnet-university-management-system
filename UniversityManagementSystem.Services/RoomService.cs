using System.Linq;
using Microsoft.EntityFrameworkCore;
using UniversityManagementSystem.Data.Contexts;
using UniversityManagementSystem.Data.Entities;

namespace UniversityManagementSystem.Services
{
    public class RoomService : ServiceBase<Room>, IRoomService
    {
        public RoomService(ApplicationDbContext context)
        {
            Context = context;
        }

        protected override ApplicationDbContext Context { get; }

        protected override DbSet<Room> DbSet => Context.Rooms;

        protected override IQueryable<Room> Queryable => DbSet
            .Include(room => room.Building)
            .ThenInclude(building => building.Campus);
    }
}