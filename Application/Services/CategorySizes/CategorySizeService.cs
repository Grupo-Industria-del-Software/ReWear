using Application.DTOs.CategorySizes;
using Application.Interfaces.CatregorySizes;
using Domain.Entities;

namespace Application.Services.CategorySizes;

public class CategorySizeService :  ICategorySizeService
{
    private readonly ICategorySizeRepository _repository;

    public CategorySizeService(ICategorySizeRepository repository)
    {
        _repository = repository;
    }
    
    public async Task<CategorySizeDto> CreateAsync(CategorySizeDto categorySizeDto)
    {
        var categorySize = new CategorySize
        {
            CategoryId = categorySizeDto.CategoryId,
            SizeId = categorySizeDto.SizeId
        };
        
        await _repository.CreateAsync(categorySize);
        
        return new CategorySizeDto
        {
            CategoryId = categorySize.CategoryId,
            SizeId = categorySize.SizeId
        };
    }

    public async Task<IEnumerable<SizeByCategoryDto>> GetAllSizeByCategoryAsync(int categoryId)
    {
        var categorySizes = await _repository.GetAllSizeByCategoryAsync(categoryId);
        return categorySizes.Select(cs => new SizeByCategoryDto()
        {
            SizeId = cs.SizeId,
            Label = cs.Size.Label
        }).ToList();
    }

    public async Task<bool> DeleteAsync(int categoryId, int sizeId)
    {
        return await _repository.DeleteAsync(categoryId, sizeId);
    }
}