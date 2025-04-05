using Application.Interfaces.Users;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AlqDbContext _context;

        public UserRepository(AlqDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task<User?> GetByEmail(string email)
        {
            return await _context.Users
                .Include(u => u.Role)
                .SingleOrDefaultAsync(u => u.Email == email);
        }

        public async Task<User?> GetById(int id)
        {
            return await _context.Users
                .Include(u => u.Role)
                .FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<bool> UpdateAsync(User user)
        {
            _context.Users.Update(user);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<User?> GetByRefreshToken(string refreshToken)
        {
            return await _context.Users
                .Include(u => u.RefreshTokens)
                .FirstOrDefaultAsync(u => u.RefreshTokens.Any(t => t.Token == refreshToken && !t.IsUsed));
        }

        public async Task<User?> GetByIdAsync(int id)
        {
            return await _context.Users
                .Include(u => u.Role)
                .Include(u => u.Subscription)
                .FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _context.Users
                .AsNoTracking()
                .Include(u => u.Role)
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.FirstName)
                .ToListAsync();
        }

        public async Task<bool> ChangeUserStatusAsync(int id, bool active)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
                return false;

            user.Active = active;
            _context.Entry(user).Property(x => x.Active).IsModified = true;
            return await _context.SaveChangesAsync() > 0;
        }
    }
}