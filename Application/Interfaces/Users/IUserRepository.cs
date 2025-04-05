using Domain.Entities;

namespace Application.Interfaces.Users;

public interface IUserRepository
{
    Task AddAsync(User user);
    Task<User?> GetByEmail(string email);
    Task<User?> GetById(int id);
    Task<bool> UpdateAsync(User user);
    Task<User?> GetByRefreshToken(string refreshToken);
    Task<User?> GetByIdAsync(int id);
    Task<IEnumerable<User>> GetAllAsync(); // Nuevo método
    Task<bool> ChangeUserStatusAsync(int id, bool active); // Nuevo método
}