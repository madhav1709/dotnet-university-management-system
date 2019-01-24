using System.Linq;
using Microsoft.EntityFrameworkCore;
using UniversityManagementSystem.Core.Data.Contexts;
using UniversityManagementSystem.Core.Data.Entities;

namespace UniversityManagementSystem.Core.Services
{
    public class RunService : ServiceBase<Run>, IRunService
    {
        public RunService(ApplicationDbContext context)
        {
            Context = context;
        }

        protected override ApplicationDbContext Context { get; }

        protected override DbSet<Run> DbSet => Context.Runs;

        protected override IQueryable<Run> Queryable => DbSet
            .Include(run => run.Module);
    }
}