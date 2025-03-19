using Application.DTOs.Auth;

namespace Application.Interfaces.Auth;

public interface IAuthService
{
    Task<RegisterResponseDto> RegisterAsync(RegisterRequestDto registerRequestDto);
    Task<LoginResponseDto?> LoginAsync(LoginRequestDto loginRequestDto);
}