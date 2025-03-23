using Domain.Common;
using Domain.Entities;

namespace Domain.AggregateRoots.Products;

public class Product : AggregateRoot
{
    public int UserId { get; set; }
    public User? User { get; set; }
    
    public int CategoryId { get; set; }
    public Category? Category { get; set; }
    
    public int ConditionId { get; set; }
    public Condition? Condition { get; set; }
    
    public int SizeId { get; set; }
    public Size? Size { get; set; }
    
    public int BrandId { get; set; }
    public Brand? Brand { get; set; }
    
    public int ProductStatusId { get; set; }
    public ProductStatus? ProductStatus { get; set; }
    
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public bool IsForSale { get; set; }
    public bool IsForRental { get; set; }
    public decimal? Price { get; set; }
    public decimal? PricePerDay { get; set; }
    
    public List<ProductImage> ProductImages { get; set; } = new();
}