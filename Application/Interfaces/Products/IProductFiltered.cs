using System.Collections;
using Application.Interfaces.Specifications;
using Domain.AggregateRoots.Products;
using Domain.Common;

namespace Application.Interfaces.Products;

public interface IProductFiltered
{
    Task<IEnumerable<Product>> GetFilteredAsync(ISpecification<Product> spec);
}