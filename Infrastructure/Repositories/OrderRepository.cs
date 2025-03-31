using Application.Interfaces.Orders;
using Domain.AggregateRoots.Orders;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AlqDbContext _context;

        public OrderRepository(AlqDbContext context)
        {
            _context = context;
        }

        public async Task<Order?> GetByIdAsync(int orderId)
        {
            return await _context.Orders
                .Include(o => o.OrderItems)
                .Include(o => o.Provider)
                .Include(o => o.Customer)
                .Include(o => o.OrderStatus)
                .FirstOrDefaultAsync(o => o.Id == orderId);
        }

        public async Task AddAsync(Order order)
        {
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Order order)
        {
            _context.Orders.Update(order);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Order order)
        {
            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Order>> GetByFiltersAsync(int? customerId = null, int? providerId = null)
        {
            var query = _context.Orders
                .Include(o => o.OrderItems)
                .Include(o => o.Provider)
                .Include(o => o.Customer)
                .Include(o => o.OrderStatus)
                .AsQueryable();

            if (customerId.HasValue)
            {
                query = query.Where(o => o.CustomerId == customerId.Value);
            }

            if (providerId.HasValue)
            {
                query = query.Where(o => o.ProviderId == providerId.Value);
            }

            return await query.ToListAsync();
        }
    }
}
