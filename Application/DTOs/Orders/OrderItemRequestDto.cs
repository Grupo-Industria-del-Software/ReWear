namespace Application.DTOs.Orders
{
   public class OrderItemRequestDto
    {
        public int ProductId { get; set; }
        public DateOnly? RentalStart { get; set; }
        public DateOnly? RentalEnd { get; set; }

    }
}
