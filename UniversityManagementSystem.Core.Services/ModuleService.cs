using System.Linq;
using Microsoft.EntityFrameworkCore;
using UniversityManagementSystem.Core.Data.Contexts;
using UniversityManagementSystem.Core.Data.Entities;

namespace UniversityManagementSystem.Core.Services
{
    public class ModuleService : ServiceBase<Module>, IModuleService
    {
        public ModuleService(ApplicationDbContext context)
        {
            Context = context;
        }

        protected override ApplicationDbContext Context { get; }

        protected override DbSet<Module> DbSet => Context.Modules;

        protected override IQueryable<Module> Queryable => DbSet;
    }
}