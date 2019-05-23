using System.Linq;
using Microsoft.EntityFrameworkCore;
using UniversityManagementSystem.Data.Contexts;
using UniversityManagementSystem.Data.Entities;

namespace UniversityManagementSystem.Services
{
    public class LectureService : ServiceBase<Lecture>, ILectureService
    {
        public LectureService(ApplicationDbContext context)
        {
            Context = context;
        }

        protected override ApplicationDbContext Context { get; }

        protected override DbSet<Lecture> DbSet => Context.Lectures;

        protected override IQueryable<Lecture> Queryable => DbSet
            .Include(lecture => lecture.Run)
            .ThenInclude(run => run.Module)
            .Include(lecture => lecture.Room)
            .ThenInclude(room => room.Campus);
    }
}