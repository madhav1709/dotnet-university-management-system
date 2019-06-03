using System.Linq;
using Microsoft.EntityFrameworkCore;
using UniversityManagementSystem.Data.Contexts;
using UniversityManagementSystem.Data.Entities;

namespace UniversityManagementSystem.Services
{
    public class RefectoryService : ServiceBase<Refectory>, IRefectoryService
    {
        public RefectoryService(ApplicationDbContext context)
        {
            Context = context;
        }

        protected override ApplicationDbContext Context { get; }

        protected override DbSet<Refectory> DbSet => Context.Refectories;

        protected override IQueryable<Refectory> Queryable => DbSet
            .Include(refectory => refectory.Building)
            .ThenInclude(building => building.Campus);
    }
}