using Microsoft.AspNetCore.Http;

namespace Application.DTOs.Products;

public class ProductImageRequestDto
{
    public IFormFile? ImageFile { get; set; } 
}