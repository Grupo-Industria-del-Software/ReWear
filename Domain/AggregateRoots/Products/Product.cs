using Domain.Common;

namespace Domain.AggregateRoots.Products;

public class Product : AggregateRoot
{
    public int UserId { get; set; }
    public int CategoryId { get; set; }
    public int ConditionId { get; set; }
    public int StatusId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public decimal RentalPrice { get; set; }
    
}