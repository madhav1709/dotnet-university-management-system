using System.Linq;
using Microsoft.EntityFrameworkCore;
using UniversityManagementSystem.Data.Contexts;
using UniversityManagementSystem.Data.Entities;

namespace UniversityManagementSystem.Services
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