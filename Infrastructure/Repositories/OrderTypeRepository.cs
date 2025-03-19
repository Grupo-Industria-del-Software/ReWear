using Application.Interfaces.OrderTypes;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Net.Http.Headers;

namespace Infrastructure.Repositories
{
    public class OrderTypeRepository : IOrderTypeRepository
    {
        private readonly AlqDbContext _context;

        public OrderTypeRepository(AlqDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<OrderType>> GetAllAsync()
        {
            return await _context.OrderTypes.ToListAsync();
        }

        public async Task<OrderType?> GetByIdAsync(int id)
        {
            return await _context.OrderTypes.FindAsync(id);
        }

        public async Task AddAsync(OrderType orderType)
        {
            _context.OrderTypes.Add(orderType);
            await _context.SaveChangesAsync();
        }
        public async Task<bool> UpdateAsync(OrderType orderType)
        {
            _context.OrderTypes.Update(orderType);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var orderType = await _context.OrderTypes.FindAsync(id);
            if (orderType == null) return false;
            _context.OrderTypes.Remove(orderType);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
