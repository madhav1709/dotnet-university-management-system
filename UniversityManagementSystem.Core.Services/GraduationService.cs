using System.Linq;
using Microsoft.EntityFrameworkCore;
using UniversityManagementSystem.Core.Data.Contexts;
using UniversityManagementSystem.Core.Data.Entities;

namespace UniversityManagementSystem.Core.Services
{
    public class GraduationService : ServiceBase<Graduation>, IGraduationService
    {
        public GraduationService(ApplicationDbContext context)
        {
            Context = context;
        }

        protected override ApplicationDbContext Context { get; }

        protected override DbSet<Graduation> DbSet => Context.Graduations;

        protected override IQueryable<Graduation> Queryable => DbSet
            .Include(graduation => graduation.Course)
            .ThenInclude(course => course.Campus);
    }
}