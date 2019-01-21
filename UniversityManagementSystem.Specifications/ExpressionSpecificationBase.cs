using System;
using System.Linq.Expressions;

namespace UniversityManagementSystem.Specifications
{
    /// <inheritdoc cref="IExpressionSpecification{TEntity}" />
    /// <summary>
    ///     Defines generic implementations for members which are shared between expression specifications.
    /// </summary>
    public abstract class ExpressionSpecificationBase<TEntity> : SpecificationBase<TEntity>,
        IExpressionSpecification<TEntity>
    {
        /// <inheritdoc />
        public override bool IsSatisfiedBy(TEntity value)
        {
            return Expression.Compile()(value);
        }

        /// <inheritdoc />
        public abstract Expression<Func<TEntity, bool>> Expression { get; }
    }
}