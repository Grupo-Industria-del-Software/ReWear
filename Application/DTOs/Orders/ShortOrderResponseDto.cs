namespace Application.DTOs.Orders;

public class ShortOrderResponseDto
{
    public int id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string OrderStatus { get; set; } = string.Empty;
    public decimal TotalPrice { get; set; }
    public DateTime CreatedAt { get; set; }
}