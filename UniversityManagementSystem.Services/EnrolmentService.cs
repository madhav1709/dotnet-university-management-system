using System.Linq;
using Microsoft.EntityFrameworkCore;
using UniversityManagementSystem.Data.Contexts;
using UniversityManagementSystem.Data.Entities;

namespace UniversityManagementSystem.Services
{
    public class EnrolmentService : ServiceBase<Enrolment>, IEnrolmentService
    {
        public EnrolmentService(ApplicationDbContext context)
        {
            Context = context;
        }

        protected override ApplicationDbContext Context { get; }

        protected override DbSet<Enrolment> DbSet => Context.Enrolments;

        protected override IQueryable<Enrolment> Queryable => DbSet
            .Include(enrolment => enrolment.Run)
            .ThenInclude(run => run.Module);
    }
}