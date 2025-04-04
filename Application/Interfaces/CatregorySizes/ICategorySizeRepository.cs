using Domain.Entities;

namespace Application.Interfaces.CatregorySizes;

public interface ICategorySizeRepository
{
    Task<CategorySize> CreateAsync(CategorySize categorySize);
    Task<List<CategorySize>> GetAllSizeByCategoryAsync(int categoryId);
}