using System.Linq;
using Microsoft.EntityFrameworkCore;
using UniversityManagementSystem.Core.Data.Contexts;
using UniversityManagementSystem.Core.Data.Entities;

namespace UniversityManagementSystem.Core.Services
{
    public class HallService : ServiceBase<Hall>, IHallService
    {
        public HallService(ApplicationDbContext context)
        {
            Context = context;
        }

        protected override ApplicationDbContext Context { get; }

        protected override DbSet<Hall> DbSet => Context.Halls;

        protected override IQueryable<Hall> Queryable => DbSet
            .Include(hall => hall.Campus);
    }
}