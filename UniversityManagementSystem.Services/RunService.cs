using System.Linq;
using Microsoft.EntityFrameworkCore;
using UniversityManagementSystem.Data.Contexts;
using UniversityManagementSystem.Data.Entities;

namespace UniversityManagementSystem.Services
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