using System.Linq;
using Microsoft.EntityFrameworkCore;
using UniversityManagementSystem.Data.Contexts;
using UniversityManagementSystem.Data.Entities;

namespace UniversityManagementSystem.Services
{
    public class SchoolService : ServiceBase<School>, ISchoolService
    {
        public SchoolService(ApplicationDbContext context)
        {
            Context = context;
        }

        protected override ApplicationDbContext Context { get; }

        protected override DbSet<School> DbSet => Context.Schools;

        protected override IQueryable<School> Queryable => DbSet
            .Include(school => school.Campus);
    }
}