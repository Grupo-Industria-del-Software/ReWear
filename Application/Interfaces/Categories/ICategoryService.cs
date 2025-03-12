using Application.DTOs.CategoriesDTO;

namespace Application.Interfaces.Categories;

public interface ICategoryService
{
    Task<IEnumerable<CategoryResponseDTO>> GetAllAsync();
    Task<CategoryResponseDTO?> GetByIdAsync(int id);
    Task<CategoryResponseDTO> CreateAsync(CategoryRequestDTO statusRequestDto);
    Task<bool> UpdateAsync(int  id, CategoryRequestDTO statusRequestDto);
    Task<bool> DeleteAsync(int id);
}