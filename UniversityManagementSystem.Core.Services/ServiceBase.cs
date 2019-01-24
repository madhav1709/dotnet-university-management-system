using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UniversityManagementSystem.Core.Data.Contexts;
using UniversityManagementSystem.Core.Data.Entities;
using UniversityManagementSystem.Exceptions;
using UniversityManagementSystem.Specifications;

namespace UniversityManagementSystem.Core.Services
{
    /// <inheritdoc />
    /// <summary>
    ///     Defines generic implementations for members which are shared between services.
    /// </summary>
    public abstract class ServiceBase<TEntity> : IService<TEntity> where TEntity : class, IEntity
    {
        protected abstract ApplicationDbContext Context { get; }

        protected abstract DbSet<TEntity> DbSet { get; }

        protected abstract IQueryable<TEntity> Queryable { get; }

        /// <inheritdoc />
        public async Task AddAsync(TEntity entity)
        {
            await DbSet.AddAsync(entity);
        }

        /// <inheritdoc />
        public async Task DeleteAsync(int id)
        {
            var entity = await GetAsync(id);

            if (entity == null) throw new EntityNotFoundException();

            DbSet.Remove(entity);

            await Context.SaveChangesAsync();
        }

        /// <inheritdoc />
        public async Task<IEnumerable<TEntity>> GetAsync()
        {
            return await Queryable.ToListAsync();
        }

        /// <inheritdoc />
        public async Task<TEntity> GetAsync(int id)
        {
            return await Queryable.SingleOrDefaultAsync(entity => entity.Id == id);
        }

        /// <inheritdoc />
        public async Task<IEnumerable<TEntity>> GetAsync(ISpecification<TEntity> specification)
        {
            return await Queryable.Where(entity => specification.IsSatisfiedBy(entity)).ToListAsync();
        }

        /// <inheritdoc />
        public async Task UpdateAsync(TEntity entity)
        {
            DbSet.Update(entity);

            await Context.SaveChangesAsync();
        }
    }
}