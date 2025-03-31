

using Application.DTOs.Orders;

namespace Application.Interfaces.Orders
{
    public interface IOrderService
    {
        Task<OrderResponseDTO> CreateOrderAsync(OrderRequestDTO request);
        Task<decimal> CalculateOrderTotalAsync(int orderId);
        Task<OrderResponseDTO> GetOrderByIdAsync(int id);
        Task<bool> UpdateOrderStatusAsync(int orderId, int statusId);
        Task<OrderItemResponseDTO> AddItemToOrderAsync(int orderId, OrderItemRequestDTO item);
        Task<bool> RemoveItemFromOrderAsync(int orderId, int itemId);
        Task<bool> UpdateOrderItemAsync(int orderId, int itemId, OrderItemRequestDTO request);
    }
}
