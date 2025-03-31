using Application.DTOs.Products;
using Microsoft.AspNetCore.Http;

namespace Application.Interfaces.Products;

public interface IProductCrud
{
    Task<IEnumerable<ProductResponseDto>> GetAllAsync(ProductFilterDto filterDto);
    Task<ProductResponseDto?> GetByIdAsync(int id);
    Task<ProductResponseDto> CreateAsync(int userId, ProductRequestDto dto, List<IFormFile> images);    
    Task<bool> UpdateAsync(int id, ProductUpdateRequestDto dto);
    Task<bool> DeleteAsync(int id);
}