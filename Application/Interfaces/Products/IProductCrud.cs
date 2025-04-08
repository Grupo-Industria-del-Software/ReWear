using Application.DTOs.Products;
using Microsoft.AspNetCore.Http;

namespace Application.Interfaces.Products;

public interface IProductCrud
{
    Task<IEnumerable<ShortProductResponseDto>> GetAllAsync(ProductFilterDto filterDto);
    Task<IEnumerable<ShortProductResponseDto>> GetAllByUserIdAsync(ProductFilterDto filterDto, int userId);
    Task<ProductResponseDto?> GetByIdAsync(int id);
    Task<ProductResponseDto> CreateAsync(int userId, ProductRequestDto dto, List<IFormFile> images);    
    Task<bool> UpdateAsync(int id, ProductUpdateRequestDto dto, List<IFormFile> images);    Task<bool> DeleteAsync(int id);
    Task<bool> DeleteImageOfProductAsync(int imageId);
}