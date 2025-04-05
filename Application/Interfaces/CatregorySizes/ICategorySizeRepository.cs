using Application.DTOs.CategorySizes;
using Domain.Entities;

namespace Application.Interfaces.CatregorySizes;

public interface ICategorySizeRepository
{
    Task CreateAsync(CategorySize categorySize);
    Task<IEnumerable<CategorySize>> GetAllSizeByCategoryAsync(int categoryId);
    Task<bool> DeleteAsync(int categoryId, int sizeId);
}