using Application.DTOs.Auth;
using Application.DTOs.Catalogs;

namespace Application.DTOs.Products;

public class ProductResponseDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal? Price { get; set; }
    public decimal? PricePerDay { get; set; }
    public bool? IsForSale { get; set; }
    public bool? IsForRental { get; set; }
    
    public List<ProductImageResponseDto>? ProductImages { get; set; }
    
    public UserResponseDTO?  User { get; set; } 
    public CatalogResponseDTO?  Category { get; set; }
    public CatalogResponseDTO?  Condition { get; set; }
    public CatalogResponseDTO? Size { get; set; }
    public CatalogResponseDTO? Brand { get; set; }
    public CatalogResponseDTO? ProductStatus { get; set; }

}