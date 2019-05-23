using System.Linq;
using Microsoft.EntityFrameworkCore;
using UniversityManagementSystem.Data.Contexts;
using UniversityManagementSystem.Data.Entities;

namespace UniversityManagementSystem.Services
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