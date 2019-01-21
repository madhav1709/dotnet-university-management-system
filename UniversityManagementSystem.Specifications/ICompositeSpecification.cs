namespace UniversityManagementSystem.Specifications
{
    /// <inheritdoc />
    /// <summary>
    ///     Declares generic members that each composite specification must implement.
    /// </summary>
    public interface ICompositeSpecification<TEntity> : ISpecification<TEntity>
    {
        /// <summary>
        ///     Gets the left hand side specification.
        /// </summary>
        ISpecification<TEntity> Left { get; }

        /// <summary>
        ///     Gets the right hand side specification.
        /// </summary>
        ISpecification<TEntity> Right { get; }
    }
}