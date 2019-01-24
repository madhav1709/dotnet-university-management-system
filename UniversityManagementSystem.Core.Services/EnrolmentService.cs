using System.Linq;
using Microsoft.EntityFrameworkCore;
using UniversityManagementSystem.Core.Data.Contexts;
using UniversityManagementSystem.Core.Data.Entities;

namespace UniversityManagementSystem.Core.Services
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