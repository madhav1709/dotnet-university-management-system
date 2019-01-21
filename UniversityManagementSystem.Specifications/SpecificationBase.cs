namespace UniversityManagementSystem.Specifications
{
    /// <inheritdoc />
    /// <summary>
    ///     Defines generic implementations for members which are shared between specifications.
    /// </summary>
    public abstract class SpecificationBase<TEntity> : ISpecification<TEntity>
    {
        /// <inheritdoc />
        public ISpecification<TEntity> And(ISpecification<TEntity> other)
        {
            return new AndSpecification<TEntity>(this, other);
        }

        /// <inheritdoc />
        public ISpecification<TEntity> Or(ISpecification<TEntity> other)
        {
            return new OrSpecification<TEntity>(this, other);
        }

        /// <inheritdoc />
        public abstract bool IsSatisfiedBy(TEntity value);

        /// <summary>
        ///     Performs an and operation between two specifications.
        /// </summary>
        /// <param name="left">The left hand side specification.</param>
        /// <param name="right">The right hand side specification.</param>
        /// <returns>The anded specification.</returns>
        public static ISpecification<TEntity> operator &(SpecificationBase<TEntity> left,
            SpecificationBase<TEntity> right)
        {
            return new AndSpecification<TEntity>(left, right);
        }

        /// <summary>
        ///     Performs an or operation between two specifications.
        /// </summary>
        /// <param name="left">The left hand side specification.</param>
        /// <param name="right">The right hand side specification.</param>
        /// <returns>The ored specification.</returns>
        public static ISpecification<TEntity> operator |(SpecificationBase<TEntity> left,
            SpecificationBase<TEntity> right)
        {
            return new OrSpecification<TEntity>(left, right);
        }
    }
}