using System.Xml;
using Application.DTOs.OrderTypes;
using Application.Interfaces.OrderTypes;

namespace Application.Services.OrderTypes
{
    public class OrderTypeService : IOrderTypeService
    {
        private readonly IOrderTypeRepository _orderTypeRepository;

        public OrderTypeService(IOrderTypeRepository orderTypeRepository)
        {
            _orderTypeRepository = orderTypeRepository;
        }

        public async Task<IEnumerable<OrderTypeResponseDTO>> GetAllAsync()
        {
            var orderTypes = await _orderTypeRepository.GetAllAsync();
            return orderTypes.Select(orderType => new OrderTypeResponseDTO
            {
                Id = orderType.Id,
                Type = orderType.Type
            });
        }
        public async Task<OrderTypeResponseDTO> GetByIdAsync(int id)
        {
            var product = await _orderTypeRepository.GetByIdAsync(id);
            return product is null ? null : new OrderTypeResponseDTO { Id = product.Id, Type = product.Type };

        }
        public async Task<OrderTypeResponseDTO> CreateAsync(OrderTypeRequestDTO dto)
        {
            var product = new Domain.Entities.OrderType(dto.Type);
            await _orderTypeRepository.AddAsync(product);
            return new OrderTypeResponseDTO { Id = product.Id, Type = product.Type };
        }

        public async Task<bool> UpdateAsync(int id, OrderTypeRequestDTO dto)
        {
            var product = await _orderTypeRepository.GetByIdAsync(id);

            if (product is null)
                return false;

            product.Type = dto.Type;

            return await _orderTypeRepository.UpdateAsync(product);
        }
        public async Task<bool> DeleteAsync(int id)
        {
            return await _orderTypeRepository.DeleteAsync(id);
        }
    }
}