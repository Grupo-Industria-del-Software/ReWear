using Application.DTOs.PaymentMethods;
using Application.Interfaces.PaymentMethods;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("/api/PaymentMethod")]
    public class PaymentMethodController :  ControllerBase
    {
        private readonly IPaymentMethodService _paymentMethodService;

        public PaymentMethodController(IPaymentMethodService paymentMethodService)
        {
            _paymentMethodService = paymentMethodService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] bool? isActive = null)
        {
            var result = await _paymentMethodService.GetAllAsync(isActive);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var paymentMethod = await _paymentMethodService.GetByIdAsync(id);
            return paymentMethod is null ? NotFound() : Ok(paymentMethod);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] PaymentMethodRequestDTO dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var created = await _paymentMethodService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] PaymentMethodRequestDTO dto) 
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var result = await _paymentMethodService.UpdateAsync(id, dto);
            return result ? NoContent() : NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _paymentMethodService.DeleteAsync(id);
            return result ? NoContent() : NotFound();
        }

        [HttpPatch("{id}/deactivate")]
        public async Task<IActionResult> Deactivate(int id)
        {
            var result = await _paymentMethodService.DeactivateAsync(id);
            return result ? NoContent() : NotFound();
        }

    }
}