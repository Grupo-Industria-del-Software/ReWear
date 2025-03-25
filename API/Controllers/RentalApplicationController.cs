using Microsoft.AspNetCore.Mvc;
using Application.DTOs.Catalogs;
using Application.DTOs.RentalApplications;
using Application.Interfaces.RentalApplications;
using Microsoft.AspNetCore.Authorization;

namespace API.Controllers
{
    [Route("api/RentalApplication")]
    [ApiController]
    public class RentalApplicationsController : ControllerBase
    {
        private readonly IRentalApplicationService _rentalApplicationService;

        public RentalApplicationsController(IRentalApplicationService rentalApplicationService)
        {
            _rentalApplicationService = rentalApplicationService;
        }

        [HttpPost]
        public async Task<ActionResult<RentalApplicationResponseDTO>> CreateRentalApplication(
            [FromBody] RentalApplicationRequestDTO request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var result = await _rentalApplicationService.CreateRentalApplicationAsync(request, request.RequesterUserId);
                return CreatedAtAction(nameof(GetRentalApplicationById), new { id = result.Id }, result);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RentalApplicationResponseDTO>> GetRentalApplicationById(int id)
        {
            var application = await _rentalApplicationService.GetRentalApplicationByIdAsync(id);

            if (application == null)
                return NotFound();

            return Ok(application);
        }

        [HttpGet("my-applications")]
        public async Task<ActionResult<IEnumerable<RentalApplicationResponseDTO>>> GetMyApplications([FromQuery] int userId)
        {
            var applications = await _rentalApplicationService.GetUserRentalApplicationsAsync(userId);
            return Ok(applications);
        }

        [HttpPatch("{applicationId}/status")]
        public async Task<IActionResult> UpdateStatus(int applicationId, [FromBody] int statusId)
        {
            await _rentalApplicationService.UpdateRentalApplicationStatusAsync(applicationId, statusId);
            return NoContent();
        }

        [HttpGet("product/{productId}")]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<RentalApplicationResponseDTO>>> GetByProductId(int productId)
        {
            var applications = await _rentalApplicationService.GetRentalApplicationsByProductIdAsync(productId);
            return Ok(applications);
        }

        [HttpDelete("{applicationId}")]
        public async Task<IActionResult> DeleteRentalApplication(int applicationId, [FromQuery] int userId)
        {
            var deletedApplication = await _rentalApplicationService.DeleteRentalApplicationAsync(applicationId, userId);
            return Ok(deletedApplication);
        }
    }
}

