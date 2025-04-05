using Application.DTOs.Users;
using Application.Interfaces.Users;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;

    public UsersController(IUserService userService)
    {
        _userService = userService;
    }

    // 1. Obtener todos los usuarios
    [HttpGet]
    public async Task<ActionResult<IEnumerable<UserResponseDto>>> GetAll()
    {
        var users = await _userService.GetAllAsync();
        return Ok(users);
    }

    // 2. Cambiar estado activo/inactivo
    [HttpPatch("{id}/status")]
    public async Task<ActionResult<UserResponseDto>> ChangeStatus(int id, [FromBody] bool active)
    {
        var result = await _userService.ChangeUserStatusAsync(id, active);
        if (!result) return NotFound();

        var updatedUser = await _userService.GetByIdAsync(id);
        return Ok(updatedUser);
    }

    // 3. Actualizar datos generales ?
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateUser(int id, [FromBody] UserRequestDto userDto)
    {
        var result = await _userService.UpdateUser(id, userDto);
        return result ? NoContent() : NotFound();
    }
}