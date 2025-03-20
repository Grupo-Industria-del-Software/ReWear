using Application.DTOs.Catalogs;
using Application.Interfaces.Catalogs;
using Domain.Common;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CatalogController<T, TCatalogRequestDTO, TCatalogResponseDTO> : ControllerBase
        where T : EntityCatalog
        where TCatalogRequestDTO : CatalogRequestDTO
        where TCatalogResponseDTO : CatalogResponseDTO
    {
        private readonly ICatalogService<T, TCatalogRequestDTO, TCatalogResponseDTO> _service;

        public CatalogController(ICatalogService<T, TCatalogRequestDTO, TCatalogResponseDTO> catalogService)
        {
            _service = catalogService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var catalog = await _service.GetByIdAsync(id);
            return catalog is null ? NotFound() : Ok(catalog);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TCatalogRequestDTO dto)
        {
            var catalog = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new {id = catalog.Id}, catalog);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] TCatalogRequestDTO dto)
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
}
