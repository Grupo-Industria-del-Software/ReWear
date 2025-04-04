using Application.DTOs.CategorySizes;

namespace Application.Interfaces.CatregorySizes;

public interface ICategorySizeService
{
    Task<CategorySizeDto> CreateAsync(CategorySizeDto categorySizeDto);
    Task<List<CategorySizeDto>> GetAllSizeByCategoryAsync(int categoryId);
}