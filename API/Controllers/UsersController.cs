using System.Security.Claims;
using Application.DTOs.Users;
using Application.Interfaces.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;

    public UsersController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet("profile")]
    [Authorize]
    public async Task<IActionResult> GetById()
    {
        var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        if (userId == null)
            return Unauthorized();

        var user = await _userService.GetByIdAsync(int.Parse(userId));

        return user is null ? NotFound() : Ok(user);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<UserResponseDto>>> GetAll()
    {
        var users = await _userService.GetAllAsync();
        return Ok(users);
    }
    
    [HttpPatch("{id}/status")]
    public async Task<ActionResult<UserResponseDto>> ChangeStatus(int id, [FromBody] bool active)
    {
        var result = await _userService.ChangeUserStatusAsync(id, active);
        if (!result) return NotFound();

        var updatedUser = await _userService.GetByIdAsync(id);
        return Ok(updatedUser);
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateUser(int id, [FromBody] UserRequestDto userDto)
    {
        var result = await _userService.UpdateUser(id, userDto);
        return result ? NoContent() : NotFound();
    }
}