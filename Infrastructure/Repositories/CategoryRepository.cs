using Application.Interfaces.Categories;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class CategoryRepository : ICategoryRepository
{
    private readonly AlqDbContext _context;

    public CategoryRepository(AlqDbContext context)
    {
        _context = context;
    }
    
    public async Task<IEnumerable<Category>> GetAllAsync()
    {
        return await _context.Categories.ToListAsync();
    }

    public async Task<Category?> GetByIdAsync(int id)
    {
        return await _context.Categories.FindAsync(id);
    }

    public async Task AddAsync(Category category)
    {
        _context.Categories.Add(category);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> UpdateAsync(Category category)
    {
        _context.Categories.Update(category);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var category = await _context.Categories.FindAsync(id);

        if (category == null) return false;
        
        _context.Categories.Remove(category);
        return await _context.SaveChangesAsync() > 0;
    }
}