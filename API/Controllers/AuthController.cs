using Application.DTOs.Auth;
using Application.DTOs.RefreshTokens;
using Application.Interfaces.Auth;
using Application.Interfaces.Users;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Controller]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService  _authService;
    private readonly IUserService _userService;

    public AuthController(IAuthService authService , IUserService userService)
    {
        _authService = authService;
        _userService = userService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterRequestDto registerRequestDto, 
        [FromForm] IFormFile? profilePicture)
    {
        if (registerRequestDto is null)
        {
            return BadRequest("Invalid request");
        }
    
        var user = await _authService.RegisterAsync(registerRequestDto, profilePicture);
        return CreatedAtAction(nameof(GetById), new { id = user.Id }, user);
    }


    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequestDto? loginRequestDto)
    {
        if (loginRequestDto is null)
        {
            return BadRequest("Invalid request");
        }
        
        var response = await _authService.LoginAsync(loginRequestDto);
        return response is null ? Unauthorized() : Ok(response);
    }

    [HttpPost("refresh-token")]
    public async Task<IActionResult> RefreshToken([FromBody] ReLoginTokenRequestDto dto)
    {
        if (dto is null)
        {
            return BadRequest("Invalid request");
        }
        
        var response = await _authService.RefreshTokenAsync(dto);
        return response is null ? Unauthorized() : Ok(response);
    } 
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var user = await _userService.GetByIdAsync(id);
        return user is null ? NotFound() : Ok(user);
    }
}