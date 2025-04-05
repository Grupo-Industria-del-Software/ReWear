using Application.DTOs.CategorySizes;
using Application.Interfaces.CatregorySizes;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategorySizeController : ControllerBase
{
    private readonly ICategorySizeService _categorySizeService;

    public CategorySizeController(ICategorySizeService categorySizeService)
    {
        _categorySizeService = categorySizeService;
    }

    [HttpGet("{categoryId}")]
    public async Task<IActionResult> GetSizesByCategory(int categoryId)
    {
        var sizes = await _categorySizeService.GetAllSizeByCategoryAsync(categoryId);
        return Ok(sizes);
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody] CategorySizeDto categorySize)
    {
        var size = await _categorySizeService.CreateAsync(categorySize);
        return StatusCode(201, size);
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteAsync([FromBody] CategorySizeDto categorySize)
    {
        var deleted = await _categorySizeService.DeleteAsync(categorySize.CategoryId, categorySize.SizeId);
        return deleted ? NoContent() : NotFound();
    }
}