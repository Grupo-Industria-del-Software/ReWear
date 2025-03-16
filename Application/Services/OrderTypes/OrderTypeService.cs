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
            var orderType = await _orderTypeRepository.GetByIdAsync(id);
            return orderType is null ? null : new OrderTypeResponseDTO { Id = orderType.Id, Type = orderType.Type };

        }
        public async Task<OrderTypeResponseDTO> CreateAsync(OrderTypeRequestDTO dto)
        {
            var orderType = new Domain.Entities.OrderType(dto.Type);
            await _orderTypeRepository.AddAsync(orderType);
            return new OrderTypeResponseDTO { Id = orderType.Id, Type = orderType.Type };
        }

        public async Task<bool> UpdateAsync(int id, OrderTypeRequestDTO dto)
        {
            var orderType = await _orderTypeRepository.GetByIdAsync(id);

            if (orderType is null)
                return false;

            orderType.Type = dto.Type;

            return await _orderTypeRepository.UpdateAsync(orderType);
        }
        public async Task<bool> DeleteAsync(int id)
        {
            return await _orderTypeRepository.DeleteAsync(id);
        }
    }
}