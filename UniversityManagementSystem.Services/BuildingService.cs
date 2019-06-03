using System.Linq;
using Microsoft.EntityFrameworkCore;
using UniversityManagementSystem.Data.Contexts;
using UniversityManagementSystem.Data.Entities;

namespace UniversityManagementSystem.Services
{
    public class BuildingService : ServiceBase<Building>, IBuildingService
    {
        public BuildingService(ApplicationDbContext context)
        {
            Context = context;
        }

        protected override ApplicationDbContext Context { get; }

        protected override DbSet<Building> DbSet => Context.Buildings;

        protected override IQueryable<Building> Queryable => DbSet
            .Include(building => building.Campus);
    }
}