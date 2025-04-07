using Application.DTOs.Orders;
using Application.Interfaces.Mappers;
using Application.Interfaces.Orders;
using Application.Interfaces.Products;
using Application.Specifications;
using Domain.AggregateRoots.Orders;
using Domain.AggregateRoots.Products;
using Domain.Common;
using Domain.Entities;

namespace Application.Services.Orders
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IProductRepository _productRepository;
        private readonly IOrderMapper _orderMapper;

        public OrderService(
            IOrderRepository orderRepository,
            IProductRepository productRepository,
            IOrderMapper orderMapper)
        {
            _orderRepository = orderRepository;
            _productRepository = productRepository;
            _orderMapper = orderMapper;
        }

        public async Task<IEnumerable<ShortOrderResponseDto>> GetAllByUserId(int userId, OrderFilterDto filterDto)
        {
            var spec = new OrderSpecification(
                filterDto.CreatedAt,
                filterDto.OrderStatusId
            );
            
            var orders = await _orderRepository.GetAllByUserId(userId, spec);
            
            return orders.Select(o => new ShortOrderResponseDto
            {
                id = o.Id,
                Name = o.Customer!.FirstName + " " + o.Customer.LastName,
                OrderStatus = o.OrderStatus!.Label,
                TotalPrice = o.TotalPrice,
                CreatedAt = o.CreatedAt
            });
        }

        public async Task<CreatedOrderResponseDto> CreateOrderAsync(int userId, OrderRequestDto request)
        {
            var order = new Order
            {
                ProviderId = userId,
                CustomerId = request.CustomerId,
                CreatedAt = DateTime.UtcNow,
                OrderItems = new List<OrderItem>(),
                OrderStatusId = request.OrderStatusId
            };

            foreach (var itemRequest in request.OrderItems)
            {
                var product = await _productRepository.GetByIdAsync(itemRequest.ProductId);
                if (product == null)
                    throw new KeyNotFoundException($"Producto {itemRequest.ProductId} no encontrado");

                if (product.UserId != order.ProviderId)
                    throw new InvalidOperationException("Todos los productos de la orden deben pertenecer al mismo proveedor.");

                ValidateRentalDates(itemRequest);

                var item = new OrderItem
                {
                    ProductId = itemRequest.ProductId,
                    RentalStart = itemRequest.RentalStart,
                    RentalEnd = itemRequest.RentalEnd,
                    IsRental = itemRequest.RentalStart.HasValue || itemRequest.RentalEnd.HasValue,
                    Price = CalculatePrice(product, itemRequest)
                };

                order.OrderItems.Add(item);
            }

            order.TotalPrice = order.OrderItems.Sum(i => i.Price);
            
            await _orderRepository.AddAsync(order);
            return new CreatedOrderResponseDto
            {
                Id = order.Id,
                ProviderId = order.ProviderId,
                CustomerId = order.CustomerId,
                OrderStatusId = order.OrderStatusId,
                TotalPrice = order.TotalPrice,
                CreatedAt = order.CreatedAt,
            };
        }

        private void ValidateRentalDates(OrderItemRequestDto item)
        {
            bool hasStart = item.RentalStart.HasValue;
            bool hasEnd = item.RentalEnd.HasValue;

            if (hasStart != hasEnd)
                throw new ArgumentException("Las fechas de alquiler deben ser ambas nulas o ambas válidas");
        }

        private decimal CalculatePrice(Product product, OrderItemRequestDto itemRequest)
        {
            if (itemRequest.RentalStart.HasValue || itemRequest.RentalEnd.HasValue)
            {
                if (product.PricePerDay == null)
                    throw new InvalidOperationException("Precio de alquiler no configurado.");

                if (itemRequest.RentalEnd.Value < itemRequest.RentalStart.Value)
                    throw new InvalidOperationException("RentalEnd no puede ser anterior a RentalStart.");

                var days = itemRequest.RentalEnd.Value.DayNumber - itemRequest.RentalStart.Value.DayNumber;

                return product.PricePerDay.Value * days;
            }
            else
            {
                if (product.Price == null)
                    throw new InvalidOperationException("Precio de venta no configurado.");

                return product.Price.Value;
            }
        }

        public async Task<OrderResponseDto> GetOrderByIdAsync(int id)
        {
            var order = await _orderRepository.GetByIdAsync(id);
            if (order == null) throw new KeyNotFoundException($"Orden {id} no encontrada");
            return _orderMapper.MapToOrderResponseDTO(order);
        }


        public async Task<decimal> CalculateOrderTotalAsync(int orderId)
        {
            var order = await _orderRepository.GetByIdAsync(orderId);
            return order?.TotalPrice ?? throw new KeyNotFoundException($"Order {orderId} not found");
        }

        public async Task<bool> UpdateOrderStatusAsync(int orderId, int Id)
        {
            var order = await _orderRepository.GetByIdAsync(orderId);
            if (order == null) return false;

            order.OrderStatusId = Id;
            await _orderRepository.UpdateAsync(order);
            return true;
        }

        public async Task<bool> DeleteOrderAsync(int orderId)
        {
            var order = await  _orderRepository.GetByIdAsync(orderId);
            if (order == null) return false;
             
            return await _orderRepository.DeleteAsync(order);
        }

        public async Task<OrderItemResponseDto> AddItemToOrderAsync(int orderId, OrderItemRequestDto item)
        {
            var order = await _orderRepository.GetByIdAsync(orderId);
            if (order == null) throw new KeyNotFoundException($"Order {orderId} not found");

            var product = await _productRepository.GetByIdAsync(item.ProductId);
            if (product == null)
                throw new KeyNotFoundException($"Producto {item.ProductId} no encontrado");
            ValidateRentalDates(item);

            var newItem = new OrderItem
            {
                ProductId = item.ProductId,
                RentalStart = item.RentalStart,
                RentalEnd = item.RentalEnd,
                IsRental = item.RentalStart.HasValue || item.RentalEnd.HasValue,
                Price = CalculatePrice(product, item)
            };

            order.OrderItems.Add(newItem);
            order.TotalPrice = order.OrderItems.Sum(i => i.Price);

            await _orderRepository.UpdateAsync(order);
            return _orderMapper.MapToOrderItemResponseDTO(newItem);
        }

        public async Task<bool> RemoveItemFromOrderAsync(int orderId, int itemId)
        {
            var order = await _orderRepository.GetByIdAsync(orderId);
            if (order == null) return false;

            var item = order.OrderItems.FirstOrDefault(i => i.Id == itemId);
            if (item == null) return false;

            order.OrderItems.Remove(item);
            order.TotalPrice = order.OrderItems.Sum(i => i.Price);

            await _orderRepository.UpdateAsync(order);
            return true;
        }

        public async Task<bool> UpdateOrderItemAsync(int orderId, int itemId, OrderItemRequestDto request)
        {
            var order = await _orderRepository.GetByIdAsync(orderId);
            if (order is null) return false;

            var item = order.OrderItems.FirstOrDefault(i => i.Id == itemId);
            if (item == null) return false;

            var product = await _productRepository.GetByIdAsync(request.ProductId);
            if (product == null) throw new KeyNotFoundException("Producto no encontrado");

            ValidateRentalDates(request);

            item.ProductId = request.ProductId;
            item.RentalStart = request.RentalStart;
            item.RentalEnd = request.RentalEnd;
            item.IsRental = request.RentalStart.HasValue || request.RentalEnd.HasValue; 

            item.Price = CalculatePrice(product, request); 

            order.TotalPrice = order.OrderItems.Sum(i => i.Price);

            await _orderRepository.UpdateAsync(order);
            return true;
        }
    }
}