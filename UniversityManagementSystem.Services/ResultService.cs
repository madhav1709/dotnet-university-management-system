using System.Linq;
using Microsoft.EntityFrameworkCore;
using UniversityManagementSystem.Data.Contexts;
using UniversityManagementSystem.Data.Entities;

namespace UniversityManagementSystem.Services
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