using System.Linq;
using Microsoft.EntityFrameworkCore;
using UniversityManagementSystem.Data.Contexts;
using UniversityManagementSystem.Data.Entities;

namespace UniversityManagementSystem.Services
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