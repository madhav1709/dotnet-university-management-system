namespace UniversityManagementSystem.Specifications
{
    /// <inheritdoc cref="ICompositeSpecification{TEntity}" />
    /// <summary>
    ///     Defines generic implementations for members which are shared between composite specifications.
    /// </summary>
    public abstract class CompositeSpecificationBase<TEntity> : SpecificationBase<TEntity>,
        ICompositeSpecification<TEntity>
    {
        /// <inheritdoc />
        public abstract ISpecification<TEntity> Left { get; }

        /// <inheritdoc />
        public abstract ISpecification<TEntity> Right { get; }
    }
}