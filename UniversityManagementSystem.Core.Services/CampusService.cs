using System.Linq;
using Microsoft.EntityFrameworkCore;
using UniversityManagementSystem.Core.Data.Contexts;
using UniversityManagementSystem.Core.Data.Entities;

namespace UniversityManagementSystem.Core.Services
{
    public class CampusService : ServiceBase<Campus>, ICampusService
    {
        public CampusService(ApplicationDbContext context)
        {
            Context = context;
        }

        protected override ApplicationDbContext Context { get; }

        protected override DbSet<Campus> DbSet => Context.Campuses;

        protected override IQueryable<Campus> Queryable => DbSet;
    }
}