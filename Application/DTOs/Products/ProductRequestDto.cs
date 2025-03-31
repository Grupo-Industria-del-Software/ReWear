using Domain.AggregateRoots.Products;

namespace Application.DTOs.Products;

public class ProductRequestDto
{
    public int UserId { get; set; }
    public int CategoryId { get; set; }
    public int ConditionId { get; set; }
    public int SizeId { get; set; }
    public int BrandId { get; set; }
    public int ProductStatusId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public decimal? PricePerDay { get; set; }
    public bool IsForSale { get; set; }
    public bool IsForRental { get; set; }
}