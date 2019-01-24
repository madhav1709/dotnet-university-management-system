using System.Linq;
using Microsoft.EntityFrameworkCore;
using UniversityManagementSystem.Core.Data.Contexts;
using UniversityManagementSystem.Core.Data.Entities;

namespace UniversityManagementSystem.Core.Services
{
    public class ResultService : ServiceBase<Result>, IResultService
    {
        public ResultService(ApplicationDbContext context)
        {
            Context = context;
        }

        protected override ApplicationDbContext Context { get; }

        protected override DbSet<Result> DbSet => Context.Results;

        protected override IQueryable<Result> Queryable => DbSet
            .Include(result => result.Assignment)
            .ThenInclude(assignment => assignment.Run)
            .ThenInclude(run => run.Module);
    }
}