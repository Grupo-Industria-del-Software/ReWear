namespace Application.DTOs.Orders;

public class OrderFilterDto
{
    public DateTime? CreatedAt { get; set; }
    public int? OrderStatusId { get; set; }
}