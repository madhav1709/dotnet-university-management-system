using System.Linq;
using Microsoft.EntityFrameworkCore;
using UniversityManagementSystem.Data.Contexts;
using UniversityManagementSystem.Data.Entities;

namespace UniversityManagementSystem.Services
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