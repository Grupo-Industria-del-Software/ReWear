using Application.DTOs.PaymentMethods;

namespace Application.Interfaces.PaymentMethods
{
    public interface IPaymentMethodService 
    {
        Task<IEnumerable<PaymentMethodResponseDTO>> GetAllAsync(bool? isActive = null);
        Task<PaymentMethodResponseDTO> GetByIdAsync(int id);
        Task<PaymentMethodResponseDTO> CreateAsync(PaymentMethodRequestDTO dto);
        Task<bool> UpdateAsync(int id, PaymentMethodRequestDTO dto);
        Task<bool> DeleteAsync(int id);
        Task<bool> DeactivateAsync(int id);
    }
}
