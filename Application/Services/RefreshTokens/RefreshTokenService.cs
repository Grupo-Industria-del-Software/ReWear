using System.Security.Cryptography;
using Application.DTOs.RefreshTokens;
using Application.Interfaces.RefreshTokens;
using Domain.Entities;

namespace Application.Services.RefreshTokens;

public class RefreshTokenService : IRefreshTokenService
{
    private readonly IRefreshTokenRepository _repository;

    public RefreshTokenService(IRefreshTokenRepository repository)
    {
        _repository = repository;
    }

    public async Task<RefreshTokenResponseDto?> GetByRefreshTokenAsync(string refreshToken)
    {
        var token = await _repository.GetByRefreshTokenAsync(refreshToken);

        return token is null
            ? null
            : new RefreshTokenResponseDto
            {
                Id = token.Id,
                Token = token.Token,
                ExpiresOnUtc = token.ExpiresOnUtc,
                UserId = token.UserId,
                IsUsed = token.IsUsed,
                User = token.User
            };
    }

    public async Task<RefreshTokenResponseDto> CreateAndAddAsync(RefreshTokenRequestDto dto)
    {
        var refreshToken = Convert.ToBase64String(RandomNumberGenerator.GetBytes(64));
        
        var token = new RefreshToken
        {
            Token = refreshToken,
            UserId = dto.UserId,
            ExpiresOnUtc = DateTime.UtcNow.AddDays(7)
        };
        
        await _repository.AddAsync(token);

        return new RefreshTokenResponseDto
        {
            Id = token.Id,
            Token = refreshToken,
            ExpiresOnUtc = token.ExpiresOnUtc,
            UserId = token.UserId,
            IsUsed = token.IsUsed
        };
    }
}