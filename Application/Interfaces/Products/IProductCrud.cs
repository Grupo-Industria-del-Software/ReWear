using Application.DTOs.Products;

namespace Application.Interfaces.Products;

public interface IProductCrud
{
    Task<IEnumerable<ProductResponseDto>> GetAllAsync(ProductFilterDto filterDto);
    Task<ProductResponseDto?> GetByIdAsync(int id);
    Task<ProductResponseDto> CreateAsync(ProductRequestDto dto);
    Task<bool> UpdateAsync(int id, ProductUpdateRequestDto dto);
    Task<bool> DeleteAsync(int id);
}