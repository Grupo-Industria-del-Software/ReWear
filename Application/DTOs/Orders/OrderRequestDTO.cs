namespace Application.DTOs.Orders
{
    public class OrderRequestDTO
    {
        public int CustomerId { get; set; }
        public int OrderStatusId { get; set; }
        public required List<OrderItemRequestDTO> OrderItems { get; set; }
    }
}
