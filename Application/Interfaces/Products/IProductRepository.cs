using System.Linq.Expressions;
using Domain.AggregateRoots.Products;

namespace Application.Interfaces.Products;

public interface IProductRepository
{
    Task<IEnumerable<Product>> GetAllAsync(Expression<Func<Product, bool>>? filter = null);
    Task<Product?> GetByIdAsync(int id);
    Task AddAsync(Product product);
    Task<bool> UpdateAsync(Product product);
    Task<bool> DeleteAsync(int id);
}