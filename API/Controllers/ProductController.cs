using System.Security.Claims;
using API.Filters;
using Application.DTOs.Products;
using Application.Interfaces.Products;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{
    private readonly IProductService _service;

    public ProductController(IProductService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(
        [FromQuery]  ProductFilterDto filterDto
        )
    {
        var products = await _service.GetAllAsync(filterDto);
        return Ok(products);
    }

    [HttpGet("user")]
    [Authorize(Roles = "Seller")]
    public async Task<IActionResult> GetAllByUserId(
        [FromQuery] ProductFilterDto filterDto
    )
    {
        var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        
        if(userId == null)
            return Unauthorized();
        
        var products = await _service.GetAllByUserIdAsync(filterDto, int.Parse(userId));
        return Ok(products);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var product = await _service.GetByIdAsync(id);
        return product is null ? NotFound() : Ok(product);
    }

    [HttpPost]
    [Authorize(Roles = "Seller")]
    [ServiceFilter(typeof(SubscriptionRequirementFilter))]
    public async Task<IActionResult> Create([FromForm] ProductRequestDto dto, [FromForm] List<IFormFile> images)
    { 
        var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        
        if(userId == null)
            return Unauthorized();
        
        var  product = await _service.CreateAsync(int.Parse(userId),dto, images);
        return CreatedAtAction(nameof(GetById), new { id = product.Id }, product);
    }

    [Authorize(Roles = "Seller")]
    [HttpPatch ("{id}")]
    [ServiceFilter(typeof(SubscriptionRequirementFilter))]
    public async Task<IActionResult> Update(
        int id,
        [FromForm] ProductUpdateRequestDto dto,
        [FromForm] List<IFormFile> images)
    {
        var updated = await _service.UpdateAsync(id, dto, images);
        return updated ? NoContent() : NotFound();
    }

    [Authorize(Roles = "Seller")]
    [HttpDelete("{id}")]
    [ServiceFilter(typeof(SubscriptionRequirementFilter))]
    public async Task<IActionResult> Delete(int id)
    {
        var deleted = await _service.DeleteAsync(id);
        return deleted ? NoContent() : NotFound();
    }

    [HttpDelete("image/{id}")]
    public async Task<IActionResult> DeleteImageOfProduct(int id)
    {
        var deleted = await _service.DeleteImageOfProductAsync(id);
        return deleted ? NoContent() : NotFound();
    }
}