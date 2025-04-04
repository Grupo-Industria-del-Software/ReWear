using Application.DTOs.Municipalities;
using Application.Interfaces.Municipality;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MunicipalityController : ControllerBase
{
    private readonly IMunicipalityService _service;

    public MunicipalityController(IMunicipalityService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var municipalities = await _service.GetAllAsync();
        return Ok(municipalities);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var municipality = await _service.GetByIdAsync(id);
        return municipality == null ? NotFound() : Ok(municipality);
    }

    [HttpPost]
    public async Task<IActionResult> Create(MunicipalityRequetsDto dto)
    {
        var created = await _service.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, MunicipalityRequetsDto dto)
    {
        var updated = await _service.UpdateAsync(id, dto);
        return updated ? NoContent() : NotFound();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var deleted = await _service.DeleteAsync(id);
        return deleted ? NoContent() : NotFound();
    }
}