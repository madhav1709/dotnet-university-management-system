using System.Linq;
using Microsoft.EntityFrameworkCore;
using UniversityManagementSystem.Data.Contexts;
using UniversityManagementSystem.Data.Entities;

namespace UniversityManagementSystem.Services
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