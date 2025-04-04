using Domain.Common;

namespace Domain.AggregateRoots.Products;

public class ProductImage : Entity
{
    public int ProductId { get; set; }
    public Product? Product { get; set; }
    
    public string ImageUrl { get; set; } = string.Empty;
    
    public string PublicId { get; set; } = string.Empty;
}