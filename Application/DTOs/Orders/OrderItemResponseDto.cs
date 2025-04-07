using Application.DTOs.Products;

namespace Application.DTOs.Orders
{
    public class OrderItemResponseDto
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public string ProductSize { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public DateOnly? RentalStart { get; set; }
        public DateOnly? RentalEnd { get; set; }
        public bool IsRental { get; set; }
        public int? RentalDays { get; set; }
    }
}
