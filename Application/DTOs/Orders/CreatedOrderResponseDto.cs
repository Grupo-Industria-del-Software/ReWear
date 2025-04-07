namespace Application.DTOs.Orders;

public class CreatedOrderResponseDto
{
    public int Id { get; set; }
    public int ProviderId { get; set; }
    public int CustomerId { get; set; }
    public int OrderStatusId { get; set; }
    public decimal TotalPrice { get; set; }
    public DateTime CreatedAt { get; set; }
}