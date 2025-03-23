using Application.DTOs.Products;

namespace Application.Interfaces.Products;

public interface IProductCrud
{
    Task<IEnumerable<ProductResponseDto>> GetAllAsync();
    Task<ProductResponseDto?> GetByIdAsync(int id);
    Task<ProductResponseDto> CreateAsync(ProductRequestDto dto);
    Task<bool> UpdateAsync(int id, ProductRequestDto dto);
    Task<bool> DeleteAsync(int id);
}