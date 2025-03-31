
using Application.DTOs.Auth;

namespace Application.Interfaces.Users;

public interface IUserService
{
    Task<UserResponseDTO?> GetByIdAsync(int id);
}