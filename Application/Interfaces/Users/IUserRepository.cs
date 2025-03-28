using Domain.Entities;

namespace Application.Interfaces.Users;

public interface IUserRepository
{
    Task AddAsync(User user);
    Task<User?> GetByEmail(string email);
    Task<User?> GetByRefreshToken(string refreshToken);
}