using System.Linq;
using Microsoft.EntityFrameworkCore;
using UniversityManagementSystem.Core.Data.Contexts;
using UniversityManagementSystem.Core.Data.Entities;

namespace UniversityManagementSystem.Core.Services
{
    public class CourseService : ServiceBase<Course>, ICourseService
    {
        public CourseService(ApplicationDbContext context)
        {
            Context = context;
        }

        protected override ApplicationDbContext Context { get; }

        protected override DbSet<Course> DbSet => Context.Courses;

        protected override IQueryable<Course> Queryable => DbSet
            .Include(course => course.Campus);
    }
}