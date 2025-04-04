namespace Application.DTOs.Subscriptions;

public class SubscriptionResponseDto
{
    public int UserId { get; set; }
    public string SubscriptionId { get; set; } = string.Empty;
    public string PlanName { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public bool  IsActive { get; set; }
}