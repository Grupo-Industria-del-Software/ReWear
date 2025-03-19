using Application.DTOs.Auth;
using Application.Interfaces.Auth;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Controller]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService  _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterRequestDto? registerRequestDto)
    {
        if (registerRequestDto is null)
        {
            return BadRequest("Invalid request");
        }
        
        var user = await _authService.RegisterAsync(registerRequestDto);
        return Created(string.Empty, user);
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
}