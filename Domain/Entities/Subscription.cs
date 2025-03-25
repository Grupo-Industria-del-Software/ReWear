using Domain.Common;

namespace Domain.Entities;

public class Subscription : Entity
{
    public int UserId { get; set; }
    public User? User { get; set; }

    public string PlanName { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public bool  IsActive { get; set; }
}