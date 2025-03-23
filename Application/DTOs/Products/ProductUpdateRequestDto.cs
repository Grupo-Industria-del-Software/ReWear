namespace Application.DTOs.Products;

public class ProductUpdateRequestDto
{
    public int? CategoryId { get; set; }
    public int? ConditionId { get; set; }
    public int? SizeId { get; set; }
    public int? BrandId { get; set; }
    public string? Name { get; set; }  
    public string? Description { get; set; }
    public decimal? Price { get; set; }
    public decimal? PricePerDay { get; set; }
    public bool? IsForSale { get; set; }
    public bool? IsForRental { get; set; }
    public List<ProductImageRequestDto>? ProductImages { get; set; }
}