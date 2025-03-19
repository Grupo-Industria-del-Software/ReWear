using Domain.Entities;

namespace Application.Interfaces.PaymentMethods
{
    public interface IPaymentMethodRepository
    {
        Task<IEnumerable<PaymentMethod>> GetAllAsync(bool? isActive = null);
        Task<PaymentMethod?> GetByIdAsync(int id);
        Task AddAsync(PaymentMethod PaymentMethod);
        Task<bool> UpdateAsync(PaymentMethod PaymentMethod);
        Task<bool> DeleteAsync(int id);
        Task<bool> DeactivateAsync(int id);
    }
}
