using Application.DTOs.CategorySizes;

namespace Application.Interfaces.CatregorySizes;

public interface ICategorySizeService
{
    Task<CategorySizeDto> CreateAsync(CategorySizeDto categorySizeDto);
    Task<IEnumerable<SizeByCategoryDto>> GetAllSizeByCategoryAsync(int categoryId);
    Task<bool> DeleteAsync(int categoryId, int sizeId);
}