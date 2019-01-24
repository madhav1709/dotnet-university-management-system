using System.Collections.Generic;
using System.Threading.Tasks;
using UniversityManagementSystem.Core.Data.Entities;
using UniversityManagementSystem.Specifications;

namespace UniversityManagementSystem.Core.Services
{
    /// <summary>
    ///     Declares generic members that each service must implement.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    public interface IService<TEntity> where TEntity : IEntity
    {
        /// <summary>
        ///     Adds an entity to the repository.
        /// </summary>
        /// <param name="entity">The entity to add.</param>
        Task AddAsync(TEntity entity);

        /// <summary>
        ///     Deletes an entity from the repository.
        /// </summary>
        /// <param name="id">The id of the entity to delete.</param>
        Task DeleteAsync(int id);

        /// <summary>
        ///     Gets all the entities from the repository.
        /// </summary>
        /// <returns>All the entities.</returns>
        Task<IEnumerable<TEntity>> GetAsync();

        /// <summary>
        ///     Gets the entity which matches the id from the repository.
        /// </summary>
        /// <param name="id">The id used to search for the entity.</param>
        /// <returns>The entity which matches the id.</returns>
        Task<TEntity> GetAsync(int id);

        /// <summary>
        ///     Gets all the entities which satisfy a specification from the repository.
        /// </summary>
        /// <param name="specification">The specification used to filter all the entities.</param>
        /// <returns>All the entities which satisfy the specification.</returns>
        Task<IEnumerable<TEntity>> GetAsync(ISpecification<TEntity> specification);

        /// <summary>
        ///     Updates an entity in the repository.
        /// </summary>
        /// <param name="entity">The entity to update.</param>
        Task UpdateAsync(TEntity entity);
    }
}