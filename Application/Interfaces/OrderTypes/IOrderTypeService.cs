using Application.DTOs.OrderTypes;

namespace Application.Interfaces.OrderTypes
{
    public interface IOrderTypeService
    {
        Task<IEnumerable<OrderTypeResponseDTO>> GetAllAsync();
        Task<OrderTypeResponseDTO?> GetByIdAsync(int id);
        Task<OrderTypeResponseDTO> CreateAsync(OrderTypeRequestDTO dto);
        Task<bool> UpdateAsync(int id, OrderTypeRequestDTO dto);
        Task<bool> DeleteAsync(int id);
    }
}
