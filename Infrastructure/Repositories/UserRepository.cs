using Application.Interfaces.Users;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class UserRepository :  IUserRepository
{
    private readonly AlqDbContext _context;

    public UserRepository(AlqDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(User user)
    {
        _context.Users.Add(user);
        await _context.SaveChangesAsync();
    }

    public async Task<User?> GetByEmail(string email)
    {
        return await _context.Users
            .Include(u => u.Role)
            .SingleOrDefaultAsync(u => u.Email == email);
    }

    public async Task<User?> GetByRefreshToken(string refreshToken)
    {
        return await _context.Users
            .Include(u => u.RefreshTokens)
            .FirstOrDefaultAsync(u => u.RefreshTokens.Any(t => t.Token == refreshToken && !t.IsUsed));
    }
}