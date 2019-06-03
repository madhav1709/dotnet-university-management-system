using System.Linq;
using Microsoft.EntityFrameworkCore;
using UniversityManagementSystem.Data.Contexts;
using UniversityManagementSystem.Data.Entities;

namespace UniversityManagementSystem.Services
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
            .Include(course => course.School)
            .ThenInclude(school => school.Campus);
    }
}