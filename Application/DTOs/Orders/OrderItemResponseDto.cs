using Application.DTOs.Products;

namespace Application.DTOs.Orders
{
    public class OrderItemResponseDto
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public decimal Price { get; set; }
        public DateOnly? RentalStart { get; set; }
        public DateOnly? RentalEnd { get; set; }
        public bool IsRental { get; set; }
        public int? RentalDays { get; set; }
        public required ProductResponseDto Product { get; set; }
    }
}
