using Application.DTOs.OrderTypes;
using Application.Interfaces.OrderTypes;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.OrderTypes
{
    [ApiController]
    [Route("/api/OrderType")]
    public class OrderTypeController:ControllerBase
    {
        private readonly IOrderTypeService _orderTypeService;

        public OrderTypeController(IOrderTypeService orderTypeService)
        {
            _orderTypeService = orderTypeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _orderTypeService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var orderType = await _orderTypeService.GetByIdAsync(id);
            return orderType is null ? NotFound() : Ok(orderType);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] OrderTypeRequestDTO dto)
        {
            var orderType = await _orderTypeService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = orderType.Id }, orderType);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] OrderTypeRequestDTO dto)
        {
            var update = await _orderTypeService.UpdateAsync(id, dto);
            return update ? NoContent() : NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _orderTypeService.DeleteAsync(id);
            return deleted ? NoContent() : NotFound();
        }
    }
}
