using System.Linq.Expressions;
using Application.Interfaces.Products;
using Domain.AggregateRoots.Products;
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
    
    public async Task<IEnumerable<Product>> GetAllAsync(Expression<Func<Product, bool>>? filter = null)
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

        if(filter != null)
            query = query.Where(filter);
        
        return await query.ToListAsync();
    }

    public async Task<Product?> GetByIdAsync(int id)
    {
        return await _context.Products
            .AsNoTracking()
            .Include(p => p.ProductImages)
            .Include(p => p.User)
            .Include(p => p.Category)
            .Include(p => p.Condition)
            .Include(p => p.Size)
            .Include(p => p.Brand)
            .Include(p => p.ProductStatus)
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
}