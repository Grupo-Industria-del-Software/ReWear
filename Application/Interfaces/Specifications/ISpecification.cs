using System.Linq.Expressions;

namespace Application.Interfaces.Specifications;

public interface ISpecification<T>
{
    Expression<Func<T, bool>> Criteria { get; }
}