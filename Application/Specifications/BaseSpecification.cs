using System.Linq.Expressions;
using Application.Interfaces.Specifications;
using Domain.Common;

namespace Application.Specifications;

public class BaseSpecification<T> : ISpecification<T>
{
    public Expression<Func<T, bool>> Criteria { get; }

    public BaseSpecification(Expression<Func<T, bool>> criteria)
    {
        Criteria = criteria;
    }
}