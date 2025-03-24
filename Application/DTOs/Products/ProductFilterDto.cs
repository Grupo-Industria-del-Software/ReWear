namespace Application.DTOs.Products;

public class ProductFilterDto
{
    public int? SizeId { get; set; }
    public int? BrandId { get; set; }
    public int? ConditionId { get; set; }
    public int? CategoryId { get; set; }
    public bool? IsForRental { get; set; }
    public bool? IsForSale { get; set; }
    public decimal? MinPrice { get; set; }
    public decimal? MaxPrice { get; set; }
}