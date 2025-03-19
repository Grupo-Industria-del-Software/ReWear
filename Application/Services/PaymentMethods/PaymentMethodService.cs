using Application.DTOs.PaymentMethods;
using Application.Interfaces.PaymentMethods;

namespace Application.Services.PaymentMethods
{
    public class PaymentMethodService : IPaymentMethodService
    {
        private readonly IPaymentMethodRepository _paymentMethodRepository;

        public PaymentMethodService(IPaymentMethodRepository paymentMethodRepository)
        {
            _paymentMethodRepository = paymentMethodRepository;
        }

        public async Task<IEnumerable<PaymentMethodResponseDTO>> GetAllAsync(bool? isActive = null)
        {
            var paymentMethods = await _paymentMethodRepository.GetAllAsync(isActive);
            return paymentMethods.Select(paymentMethod => new PaymentMethodResponseDTO
            {
                Id = paymentMethod.Id,
                Name = paymentMethod.Name,
                IsActive = paymentMethod.IsActive
            });
        }

        public async Task<PaymentMethodResponseDTO?> GetByIdAsync(int id)
        {
            var paymentMethod = await _paymentMethodRepository.GetByIdAsync(id);
            return paymentMethod is null ? null : new PaymentMethodResponseDTO { Id = paymentMethod.Id, Name = paymentMethod.Name , IsActive = paymentMethod.IsActive};

        }
        public async Task<PaymentMethodResponseDTO> CreateAsync(PaymentMethodRequestDTO dto)
        {
            var paymentMethod = new Domain.Entities.PaymentMethod(dto.Name, dto.IsActive);
            await _paymentMethodRepository.AddAsync(paymentMethod);
            return new PaymentMethodResponseDTO { Id = paymentMethod.Id, Name = paymentMethod.Name, IsActive = paymentMethod.IsActive };
        }

        public async Task<bool> UpdateAsync(int id, PaymentMethodRequestDTO dto)
        {
            var paymentMethod = await _paymentMethodRepository.GetByIdAsync(id);

            if (paymentMethod is null)
                return false;

            paymentMethod.Name = dto.Name;
            paymentMethod.IsActive = dto.IsActive;

            return await _paymentMethodRepository.UpdateAsync(paymentMethod);
        }
        public async Task<bool> DeleteAsync(int id)
        {
            return await _paymentMethodRepository.DeleteAsync(id);
        }

        public async Task<bool> DeactivateAsync(int id)
        {
            var paymentMethod = await _paymentMethodRepository.GetByIdAsync(id);
            if (paymentMethod == null) return false;

            paymentMethod.IsActive = false;
            return await _paymentMethodRepository.UpdateAsync(paymentMethod);
        }
    }
}
