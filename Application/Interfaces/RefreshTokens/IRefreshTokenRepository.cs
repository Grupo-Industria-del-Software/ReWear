using Domain.Entities;

namespace Application.Interfaces.RefreshTokens;

public interface IRefreshTokenRepository
{
    Task<RefreshToken?> GetByIdAsync(int tokenId);
    Task<RefreshToken?> GetByRefreshTokenAsync(string refreshToken);
    Task AddAsync(RefreshToken refreshToken);
    Task<bool> UpdateAsync(RefreshToken refreshToken);
}