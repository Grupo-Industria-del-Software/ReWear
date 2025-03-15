using Application.DTOs;
using Application.Interfaces;
using Application.DTOs.UserRolesDTO.UserRolesDTO;
using Application.Interfaces.userRoles;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/userroles")]
    public class UserRolesController : ControllerBase
    {
        private readonly IUserRolesService _userRolesService;

        public UserRolesController(IUserRolesService userRolesService)
        {
            _userRolesService = userRolesService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _userRolesService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var role = await _userRolesService.GetByIdAsync(id);
            return role is null ? NotFound() : Ok(role);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] UserRolesRequestDTO dto)
        {
            var role = await _userRolesService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = role.Id }, role);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UserRolesRequestDTO dto)
        {
            var updated = await _userRolesService.UpdateAsync(id, dto);
            return updated ? NoContent() : NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _userRolesService.DeleteAsync(id);
            return deleted ? NoContent() : NotFound();
        }
    }
}
