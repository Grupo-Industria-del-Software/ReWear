using Application.Interfaces.PaymentMethods;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class PaymentMethodRepository : IPaymentMethodRepository
    {
        private readonly AlqDbContext _context;
        public PaymentMethodRepository(AlqDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<PaymentMethod>> GetAllAsync(bool? isActive = null)
        {
            var query = _context.PaymentMethods.AsQueryable();

            if (isActive.HasValue)
            {
                query = query.Where(paymentMethod => paymentMethod.IsActive == isActive.Value);
            }

            return await query.ToListAsync();
        }
        public async Task<PaymentMethod?> GetByIdAsync(int id)
        {
            return await _context.PaymentMethods.FindAsync(id);
        }

        public async Task AddAsync(PaymentMethod paymentMethod)
        {
            _context.PaymentMethods.Add(paymentMethod);
            await _context.SaveChangesAsync();
        }
        public async Task<bool> UpdateAsync(PaymentMethod paymentMethod)
        {
            _context.   PaymentMethods.Update(paymentMethod);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var paymentMethod = await _context.PaymentMethods.FindAsync(id);
            if (paymentMethod == null) return false;
            _context.PaymentMethods.Remove(paymentMethod);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeactivateAsync(int id)
        {
            var paymentMethod = await GetByIdAsync(id);
            if (paymentMethod == null) return false;

            paymentMethod.IsActive = false;
            _context.PaymentMethods.Update(paymentMethod);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
