using Application.DTOs.Auth;
using Application.DTOs.Catalogs;
using Application.DTOs.Users;

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
    
    public UserResponseDto?  User { get; set; } 
    public CatalogResponseDto?  Category { get; set; }
    public CatalogResponseDto?  Condition { get; set; }
    public CatalogResponseDto? Size { get; set; }
    public CatalogResponseDto? Brand { get; set; }
    public CatalogResponseDto? ProductStatus { get; set; }

}