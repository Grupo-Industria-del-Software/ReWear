using Application.Interfaces.userRoles;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class UserRolesRepository : IUserRolesRepository
    {
        private readonly AlqDbContext _context;

        public UserRolesRepository(AlqDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<UserRoles>> GetAllAsync()
        {
            return await _context.UserRoles.ToListAsync();
        }

        public async Task<UserRoles?> GetByIdAsync(int id)
        {
            return await _context.UserRoles.FindAsync(id);
        }

        public async Task AddAsync(UserRoles rol)
        {
            _context.UserRoles.Add(rol);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdateAsync(UserRoles rol)
        {
            _context.UserRoles.Update(rol);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var rol = await _context.UserRoles.FindAsync(id);
            if (rol is null) return false;

            _context.UserRoles.Remove(rol);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
