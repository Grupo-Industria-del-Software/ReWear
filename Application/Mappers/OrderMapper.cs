using Application.DTOs.Orders;
using Application.DTOs.Products;
using Application.Interfaces.Mappers;
using Domain.AggregateRoots.Orders;

namespace Application.Mappers
{
    public class OrderMapper : IOrderMapper
    {
        public OrderResponseDto MapToOrderResponseDTO(Order order)
        {
            return new OrderResponseDto
            {
                Id = order.Id,
                ProviderId = order.ProviderId,
                ProviderName = $"{order.Provider?.FirstName ?? string.Empty} {order.Provider?.LastName ?? string.Empty}",
                CustomerId = order.CustomerId,
                CustomerName = $"{order.Customer?.FirstName ?? string.Empty} {order.Customer?.LastName ?? string.Empty}",
                TotalPrice = order.TotalPrice,
                OrderStatus = order.OrderStatusId,
                OrderStatusName = order.OrderStatus?.Label ?? string.Empty,
                CreatedAt = order.CreatedAt,
                OrderItems = order.OrderItems.Select(MapToOrderItemResponseDTO).ToList()
            };
        }

        public OrderItemResponseDto MapToOrderItemResponseDTO(OrderItem item)
        {
            return new OrderItemResponseDto
            {
                Id = item.Id,
                ProductId = item.ProductId,
                ProductName = item.Product!.Name,
                ProductSize = item.Product.Size!.Label,
                Price = item.Price,
                RentalStart = item.RentalStart,
                RentalEnd = item.RentalEnd,
                IsRental = item.IsRental,
                RentalDays = item.RentalEnd.HasValue && item.RentalStart.HasValue
                             ? (item.RentalEnd.Value.DayNumber - item.RentalStart.Value.DayNumber)
                             : (int?)null
            };
        }
    }
}