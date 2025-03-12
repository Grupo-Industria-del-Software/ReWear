using Application.DTOs.CategoriesDTO;
using Application.Interfaces.Categories;
using Domain.Entities;

namespace Application.Services.CategoryServices;

public class CategoryService :  ICategoryService
{
    private readonly ICategoryRepository _repository;

    public CategoryService(ICategoryRepository repository)
    {
        _repository = repository;
    }
    
    public async Task<IEnumerable<CategoryResponseDTO>> GetAllAsync()
    {
        var categories = await _repository.GetAllAsync();
        return categories.Select(c => new CategoryResponseDTO
        {
            Id = c.Id,
            Name = c.Name,
        });
    }

    public async Task<CategoryResponseDTO?> GetByIdAsync(int id)
    {
        var category = await  _repository.GetByIdAsync(id);
        return category is null ? null : new CategoryResponseDTO
        {
            Id = category.Id,
            Name = category.Name,
        };
    }

    public async Task<CategoryResponseDTO> CreateAsync(CategoryRequestDTO statusRequestDto)
    {
        var category = new Category
        {
            Name = statusRequestDto.Name,
        };
        await _repository.AddAsync(category);

        return new CategoryResponseDTO
        {
            Id = category.Id,
            Name = category.Name,
        };
    }

    public async Task<bool> UpdateAsync(int id, CategoryRequestDTO statusRequestDto)
    {
        var category = await _repository.GetByIdAsync(id);

        if (category is null) return false;
        
        // Update data
        category.Name = statusRequestDto.Name;
        return await _repository.UpdateAsync(category);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        return await _repository.DeleteAsync(id);
    }
}