using Application.DTOs.Status;
using Application.Interfaces.Status;
using Domain.Common;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StatusController<T, TStatusRequestDTO, TStatusResponseDTO> : ControllerBase
        where T : EntityStatusCatalog
        where TStatusRequestDTO : StatusRequestDTO
        where TStatusResponseDTO : StatusResponseDTO
    {
        private readonly IStatusService<T, TStatusRequestDTO, TStatusResponseDTO> _service;

        public StatusController(IStatusService<T, TStatusRequestDTO, TStatusResponseDTO> statusService)
        {
            _service = statusService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var status = await _service.GetByIdAsync(id);
            return status is null ? NotFound() : Ok(status);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TStatusRequestDTO dto)
        {
            var status = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new {id = status.Id}, status);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] TStatusRequestDTO dto)
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
