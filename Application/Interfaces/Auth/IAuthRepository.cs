using Domain.Entities;

namespace Application.Interfaces.Auth;

public interface IAuthRepository
{
    Task AddAsync(User user);
    Task<User?> GetByEmail(string email);
}