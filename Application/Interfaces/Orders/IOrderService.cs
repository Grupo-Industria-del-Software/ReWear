

using Application.DTOs.Orders;

namespace Application.Interfaces.Orders
{
    public interface IOrderService
    {
        Task<OrderResponseDto> CreateOrderAsync(int userId, OrderRequestDto request);
        Task<decimal> CalculateOrderTotalAsync(int orderId);
        Task<OrderResponseDto> GetOrderByIdAsync(int id);
        Task<bool> UpdateOrderStatusAsync(int orderId, int statusId);
        Task<OrderItemResponseDto> AddItemToOrderAsync(int orderId, OrderItemRequestDto item);
        Task<bool> RemoveItemFromOrderAsync(int orderId, int itemId);
        Task<bool> UpdateOrderItemAsync(int orderId, int itemId, OrderItemRequestDto request);
    }
}
