using System.Linq;
using Microsoft.EntityFrameworkCore;
using UniversityManagementSystem.Core.Data.Contexts;
using UniversityManagementSystem.Core.Data.Entities;

namespace UniversityManagementSystem.Core.Services
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
            .Include(library => library.Campus);
    }
}