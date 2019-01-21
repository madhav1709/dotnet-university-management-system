namespace UniversityManagementSystem.Specifications
{
    /// <inheritdoc />
    /// <summary>
    ///     Defines implementations for the inherited members which represent an or specification.
    /// </summary>
    public class OrSpecification<TEntity> : CompositeSpecificationBase<TEntity>
    {
        /// <summary>
        ///     Constructs an instance of the or specification using a left and right specification.
        /// </summary>
        /// <param name="left">The left hand side specification.</param>
        /// <param name="right">The right hand side specification.</param>
        public OrSpecification(ISpecification<TEntity> left, ISpecification<TEntity> right)
        {
            Left = left;
            Right = right;
        }

        /// <inheritdoc />
        public override ISpecification<TEntity> Left { get; }

        /// <inheritdoc />
        public override ISpecification<TEntity> Right { get; }

        /// <inheritdoc />
        public override bool IsSatisfiedBy(TEntity value)
        {
            return Left.IsSatisfiedBy(value) || Right.IsSatisfiedBy(value);
        }
    }
}