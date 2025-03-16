using Microsoft.AspNetCore.Mvc;
using Application.Interfaces.Conditions;
using Application.DTOs.ConditionsDTOs;
using System.Threading.Tasks;
using Application.DTOs.ConditionsDTO;

namespace API.Controllers
{
    [ApiController]
    [Route("api/condition")] 
    public class ConditionController : ControllerBase
    {
        private readonly IConditionService _conditionService;

        public ConditionController(IConditionService conditionService)
        {
            _conditionService = conditionService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var conditions = await _conditionService.GetAllAsync();
            return Ok(conditions);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var condition = await _conditionService.GetByIdAsync(id);
            return condition is null ? NotFound() : Ok(condition);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ConditionRequestDTO dto)
        {
            var condition = await _conditionService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = condition.Id }, condition);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ConditionRequestDTO dto)
        {
            var updated = await _conditionService.UpdateAsync(id, dto);
            return updated ? NoContent() : NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _conditionService.DeleteAsync(id);
            return deleted ? NoContent() : NotFound();
        }
    }
}
