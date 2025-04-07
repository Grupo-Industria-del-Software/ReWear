

using Application.DTOs.Orders;
using Domain.AggregateRoots.Orders;

namespace Application.Interfaces.Orders
{
    public interface IOrderService
    {
        Task<IEnumerable<ShortOrderResponseDto>> GetAllByUserId(int userId, OrderFilterDto filterDto);
        Task<IEnumerable<ShortOrderResponseDto>> GetAllByCustomerId(int userId, OrderFilterDto filterDto);
        Task<OrderResponseDto> GetOrderByIdAsync(int id);
        Task<CreatedOrderResponseDto> CreateOrderAsync(int userId, OrderRequestDto request);
        Task<bool> UpdateOrderStatusAsync(int orderId, int statusId);
        Task<bool> DeleteOrderAsync(int orderId);
        
        Task<OrderItemResponseDto> AddItemToOrderAsync(int orderId, OrderItemRequestDto item);
        Task<bool> RemoveItemFromOrderAsync(int orderId, int itemId);
        Task<bool> UpdateOrderItemAsync(int orderId, int itemId, OrderItemRequestDto request);
        
        
        Task<decimal> CalculateOrderTotalAsync(int orderId);
    }
}
