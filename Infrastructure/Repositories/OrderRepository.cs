using Application.DTOs.Orders;
using Application.Interfaces.Orders;
using Application.Interfaces.Specifications;
using Domain.AggregateRoots.Orders;
using Domain.Common;
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

        public async Task<IEnumerable<Order>> GetAllByUserId(int userId, ISpecification<Order> spec)
        {
            IQueryable<Order> query = _context.Orders
                .AsNoTracking()
                .Where(o => o.ProviderId == userId)
                .Where(spec.Criteria)
                .Include(o => o.Provider)
                .Include(o => o.Customer)
                .Include(o => o.OrderStatus);
            
            return await query.ToListAsync();
        }

        public async Task<IEnumerable<Order>> GetAllByCustomerId(int userId, ISpecification<Order> spec)
        {
            IQueryable<Order> query = _context.Orders
                .AsNoTracking()
                .Where(o => o.CustomerId == userId)
                .Where(spec.Criteria)
                .Include(o => o.Provider)
                .Include(o => o.Customer)
                .Include(o => o.OrderStatus);
            
            return await query.ToListAsync();
        }

        public async Task<Order?> GetByIdAsync(int orderId)
        {
            return await _context.Orders
                .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.Product)
                .ThenInclude(p => p.Size)
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

        public async Task<bool> DeleteAsync(Order order)
        {
            _context.Orders.Remove(order);
            return await _context.SaveChangesAsync() > 0;
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
