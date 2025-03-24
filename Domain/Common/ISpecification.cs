using System.Linq.Expressions;

namespace Domain.Common;

public interface ISpecification<T>
{
    Expression<Func<T, bool>> Criteria { get; }
}