using Application.Interfaces.RefreshTokens;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class RefreshTokenRepository : IRefreshTokenRepository
{
    private readonly AlqDbContext _context;

    public RefreshTokenRepository(AlqDbContext context)
    {
        _context = context;
    }

    public async Task<RefreshToken?> GetByRefreshTokenAsync(string refreshToken)
    {
        return await _context.RefreshTokens
            .AsNoTracking()
            .Include(rt => rt.User)
            .FirstOrDefaultAsync(rt => rt.Token == refreshToken);
    }

    public async Task AddAsync(RefreshToken refreshToken)
    {
        _context.RefreshTokens.Add(refreshToken);
        await _context.SaveChangesAsync();
    }
}