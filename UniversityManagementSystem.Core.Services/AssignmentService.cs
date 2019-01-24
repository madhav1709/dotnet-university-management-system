using System.Linq;
using Microsoft.EntityFrameworkCore;
using UniversityManagementSystem.Core.Data.Contexts;
using UniversityManagementSystem.Core.Data.Entities;

namespace UniversityManagementSystem.Core.Services
{
    public class AssignmentService : ServiceBase<Assignment>, IAssignmentService
    {
        public AssignmentService(ApplicationDbContext context)
        {
            Context = context;
        }

        protected override ApplicationDbContext Context { get; }

        protected override DbSet<Assignment> DbSet => Context.Assignments;

        protected override IQueryable<Assignment> Queryable => DbSet
            .Include(assignment => assignment.Run)
            .ThenInclude(run => run.Module);
    }
}