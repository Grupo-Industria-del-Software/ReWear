using System.Linq.Expressions;
using Application.Interfaces.Products;
using Application.Interfaces.Specifications;
using Domain.AggregateRoots.Products;
using Domain.Common;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly AlqDbContext  _context;

    public ProductRepository(AlqDbContext context)
    {
        _context = context; 
    }
    private IQueryable<Product> GetBaseQuery(
        ISpecification<Product>? spec = null
        )
    {
        IQueryable<Product> query = _context.Products
            .AsNoTracking()
            .Include(p => p.ProductImages)
            .Include(p => p.User)
            .Include(p => p.Category)
            .Include(p => p.Condition)
            .Include(p => p.Size)
            .Include(p => p.Brand)
            .Include(p => p.ProductStatus);

        if (spec != null)
        {
            query = query.Where(spec.Criteria);
        }

        return query;
    }
    
    public async Task<IEnumerable<Product>> GetAllAsync(ISpecification<Product> spec)
    {
        return await GetBaseQuery(spec)
            .ToListAsync();
    }

    public async Task<IEnumerable<Product>> GetAllByUserIdAsync(int userId, ISpecification<Product> spec)
    {
        return await GetBaseQuery(spec)
            .Where(p => p.UserId == userId)
            .ToListAsync();
    }

    public async Task<Product?> GetByIdAsync(int id)
    {
        return await GetBaseQuery()
            .FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task AddAsync(Product product)
    {
        _context.Products.Add(product);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> UpdateAsync(Product product)
    {
        _context.Products.Update(product);
        return await _context.SaveChangesAsync() > 0; 
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var product = await _context.Products.FindAsync(id);
        if( product == null) return false;
        
        _context.Products.Remove(product);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> DeleteImageOfProductAsync(int imageId)
    {
        var img = await _context.ProductImages.FirstOrDefaultAsync(p => p.Id == imageId);
        if (img == null) return false;
        
        _context.ProductImages.Remove(img);
        return await _context.SaveChangesAsync() > 0;
    }
}