using Application.DTOs.Auth;
using Microsoft.AspNetCore.Http;

namespace Application.Interfaces.Auth;

public interface IAuthService
{
    Task<RegisterResponseDto> RegisterAsync(RegisterRequestDto registerRequestDto, IFormFile? profilePicture);
    Task<LoginResponseDto?> LoginAsync(LoginRequestDto loginRequestDto);
    public Task<LoginResponseDto?> RefreshTokenAsync(ReLoginTokenRequestDto refreshTokenRequestDto);
}