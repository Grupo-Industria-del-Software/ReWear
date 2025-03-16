using Application.Interfaces.Conditions;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class ConditionRepository : IConditionRepository
    {
        private readonly AlqDbContext _context;

        public ConditionRepository(AlqDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Condition>> GetAllAsync()
        {
            return await _context.Conditions.ToListAsync();
        }

        public async Task<Condition?> GetByIdAsync(int id)
        {
            return await _context.Conditions.FindAsync(id);
        }

        public async Task AddAsync(Condition condition)
        {
            _context.Conditions.Add(condition);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdateAsync(Condition condition)
        {
            _context.Conditions.Update(condition);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var condition = await _context.Conditions.FindAsync(id);

            if (condition == null)
                return false;

            _context.Conditions.Remove(condition);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
