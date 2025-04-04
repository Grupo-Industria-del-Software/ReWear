namespace Application.DTOs.Orders
{
    public class OrderRequestDto
    {
        public int CustomerId { get; set; }
        public int OrderStatusId { get; set; }
        public required List<OrderItemRequestDto> OrderItems { get; set; }
    }
}
