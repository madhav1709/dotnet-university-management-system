using System.Linq;
using Microsoft.EntityFrameworkCore;
using UniversityManagementSystem.Core.Data.Contexts;
using UniversityManagementSystem.Core.Data.Entities;

namespace UniversityManagementSystem.Core.Services
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