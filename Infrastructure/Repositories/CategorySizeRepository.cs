using Application.DTOs.CategorySizes;
using Application.Interfaces.CatregorySizes;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class CategorySizeRepository :  ICategorySizeRepository
{
    private readonly AlqDbContext  _context;

    public CategorySizeRepository(AlqDbContext context)
    {
        _context = context;
    }
    
    public async Task CreateAsync(CategorySize categorySize)
    {
        _context.Add(categorySize);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<CategorySize>> GetAllSizeByCategoryAsync(int categoryId)
    {
        return await _context.CategorySizes
            .AsNoTracking()
            .Include(cs => cs.Size)
            .Where(cs => cs.CategoryId == categoryId && cs.Size!.IsActive)
            .ToListAsync();
    }

    public async Task<bool> DeleteAsync(int categoryId, int sizeId)
    {
        var toDelete = new CategorySize
        {
            CategoryId = categoryId,
            SizeId = sizeId
        };
        
        _context.CategorySizes.Remove(toDelete);
        return await _context.SaveChangesAsync() > 0;
    }
}