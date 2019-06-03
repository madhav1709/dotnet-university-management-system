using System.Linq;
using Microsoft.EntityFrameworkCore;
using UniversityManagementSystem.Data.Contexts;
using UniversityManagementSystem.Data.Entities;

namespace UniversityManagementSystem.Services
{
    public class LibraryService : ServiceBase<Library>, ILibraryService
    {
        public LibraryService(ApplicationDbContext context)
        {
            Context = context;
        }

        protected override ApplicationDbContext Context { get; }

        protected override DbSet<Library> DbSet => Context.Libraries;

        protected override IQueryable<Library> Queryable => DbSet
            .Include(library => library.Building)
            .ThenInclude(building => building.Campus);
    }
}