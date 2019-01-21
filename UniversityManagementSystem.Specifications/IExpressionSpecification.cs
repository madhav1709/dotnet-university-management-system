using System;
using System.Linq.Expressions;

namespace UniversityManagementSystem.Specifications
{
    /// <inheritdoc />
    /// <summary>
    ///     Declares generic members that each expression specification must implement.
    /// </summary>
    public interface IExpressionSpecification<TEntity> : ISpecification<TEntity>
    {
        /// <summary>
        ///     Gets the expression.
        /// </summary>
        Expression<Func<TEntity, bool>> Expression { get; }
    }
}