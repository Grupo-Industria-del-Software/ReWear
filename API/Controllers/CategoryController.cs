using Application.DTOs.CategoriesDTO;
using Application.Interfaces.Categories;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Controller]
[Route("api/Category")]
public class CategoryController : ControllerBase
{
    private readonly ICategoryService _service;

    public CategoryController(ICategoryService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _service.GetAllAsync());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var  category = await _service.GetByIdAsync(id);
        return category == null ? NotFound() : Ok(category);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CategoryRequestDTO categoryRequestDto)
    {
        var category = await _service.CreateAsync(categoryRequestDto);
        
        return CreatedAtAction(nameof(GetById), new { id = category.Id }, category);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] CategoryRequestDTO categoryRequestDto)
    {
        var updated = await _service.UpdateAsync(id, categoryRequestDto);
        return updated ? NoContent() : NotFound();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var deleted = await _service.DeleteAsync(id);
        return deleted ? NoContent() : NotFound();
    }
}