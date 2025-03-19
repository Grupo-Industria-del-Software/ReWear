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
        return await _context.Municipalities.ToListAsync();
    }

    public async Task<Municipality?> GetByIdAsync(int id)
    {
        return await _context.Municipalities.FindAsync(id);
    }

    public async Task AddAsync(Municipality municipality)
    {
        await _context.Municipalities.AddAsync(municipality);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> UpdateAsync(Municipality municipality)
    {
        _context.Municipalities.Update(municipality);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var municipality = await _context.Municipalities.FindAsync(id);
        if (municipality == null) return false;

        _context.Municipalities.Remove(municipality);
        return await _context.SaveChangesAsync() > 0;
    }
}