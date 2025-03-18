using Application.Interfaces.Municipality;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class MunicipalityRepository: IMunicipalityRepository
{
    private readonly AlqDbContext _context;

    public MunicipalityRepository(AlqDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Municipality>> GetAllAsync()
    {
        return await _context.municipalities.ToListAsync();
    }

    public async Task<Municipality?> GetByIdAsync(int id)
    {
        return await _context.municipalities.FindAsync(id);
    }

    public async Task AddAsync(Municipality municipality)
    {
        await _context.municipalities.AddAsync(municipality);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> UpdateAsync(Municipality municipality)
    {
        _context.municipalities.Update(municipality);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var municipality = await _context.municipalities.FindAsync(id);
        if (municipality == null) return false;

        _context.municipalities.Remove(municipality);
        return await _context.SaveChangesAsync() > 0;
    }
}