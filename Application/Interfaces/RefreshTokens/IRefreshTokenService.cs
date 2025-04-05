using Application.DTOs.RefreshTokens;
using Domain.Entities;

namespace Application.Interfaces.RefreshTokens;

public interface IRefreshTokenService
{
    Task<RefreshTokenResponseDto?> GetByRefreshTokenAsync(string refreshToken);
    Task<RefreshTokenResponseDto> CreateAndAddAsync(RefreshTokenRequestDto dto);
    Task<bool> MarkAsUsedAsync(int id);
}