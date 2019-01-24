using System.Linq;
using Microsoft.EntityFrameworkCore;
using UniversityManagementSystem.Core.Data.Contexts;
using UniversityManagementSystem.Core.Data.Entities;

namespace UniversityManagementSystem.Core.Services
{
    public class BookService : ServiceBase<Book>, IBookService
    {
        public BookService(ApplicationDbContext context)
        {
            Context = context;
        }

        protected override ApplicationDbContext Context { get; }

        protected override DbSet<Book> DbSet => Context.Books;

        protected override IQueryable<Book> Queryable => DbSet;
    }
}