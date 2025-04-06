namespace Application.DTOs.Products;

public class ShortProductResponseDto
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Category { get; set; } = string.Empty;
    public string Condition { get; set; } = string.Empty;
    public string Size { get; set; } = string.Empty;
    public string Brand { get; set; } = string.Empty;
    public string ProductStatus { get; set; } = string.Empty;
    public bool IsForRental { get; set; }
    public decimal? Price { get; set; }
    public decimal? PricePerDay { get; set; }
    
    public IEnumerable<ProductImageResponseDto> Images { get; set; } = new List<ProductImageResponseDto>();
}