using Application.DTOs.Orders;
using Domain.AggregateRoots.Orders;

namespace Application.Interfaces.Mappers
{
    public interface IOrderMapper
    {
        OrderResponseDto MapToOrderResponseDTO(Order order);
        OrderItemResponseDto MapToOrderItemResponseDTO(OrderItem item);
    }
}
