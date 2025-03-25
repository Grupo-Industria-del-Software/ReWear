using Domain.Entities;

namespace Application.Interfaces.RefreshTokens;

public interface IRefreshTokenRepository
{
    Task<RefreshToken?> GetByRefreshTokenAsync(string refreshToken);
    Task AddAsync(RefreshToken refreshToken);
}