namespace Application.DTOs.Orders
{
   public class OrderItemRequestDTO
    {
        public int ProductId { get; set; }
        public DateOnly? RentalStart { get; set; }
        public DateOnly? RentalEnd { get; set; }

    }
}
