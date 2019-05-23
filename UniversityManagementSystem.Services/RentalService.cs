using System.Linq;
using Microsoft.EntityFrameworkCore;
using UniversityManagementSystem.Data.Contexts;
using UniversityManagementSystem.Data.Entities;

namespace UniversityManagementSystem.Services
{
    public class RentalService : ServiceBase<Rental>, IRentalService
    {
        public RentalService(ApplicationDbContext context)
        {
            Context = context;
        }

        protected override ApplicationDbContext Context { get; }

        protected override DbSet<Rental> DbSet => Context.Rentals;

        protected override IQueryable<Rental> Queryable => DbSet
            .Include(rental => rental.Book);
    }
}