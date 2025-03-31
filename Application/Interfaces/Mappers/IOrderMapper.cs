using Application.DTOs.Orders;
using Domain.AggregateRoots.Orders;

namespace Application.Interfaces.Mappers
{
    public interface IOrderMapper
    {
        OrderResponseDTO MapToOrderResponseDTO(Order order);
        OrderItemResponseDTO MapToOrderItemResponseDTO(OrderItem item);
    }
}
