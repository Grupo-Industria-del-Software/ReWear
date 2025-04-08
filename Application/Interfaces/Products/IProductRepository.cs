using System.Linq.Expressions;
using Application.Interfaces.Specifications;
using Domain.AggregateRoots.Products;
using Domain.Common;

namespace Application.Interfaces.Products;

public interface IProductRepository
{
    Task<IEnumerable<Product>> GetAllAsync(ISpecification<Product> spec);
    Task<IEnumerable<Product>> GetAllByUserIdAsync(int userId, ISpecification<Product> spec);
    Task<Product?> GetByIdAsync(int id);
    Task AddAsync(Product product);
    Task<bool> UpdateAsync(Product product);
    Task<bool> DeleteAsync(int id);
    
    Task<bool> DeleteImageOfProductAsync(int imageId);
}