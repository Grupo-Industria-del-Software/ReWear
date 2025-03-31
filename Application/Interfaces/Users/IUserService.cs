using Application.DTOs.Users;

using Application.DTOs.Auth;

namespace Application.Interfaces.Users;

public interface IUserService
{
    Task<bool> UpdateUser(int id, UserRequestDto dto);
    Task<UserResponseDTO?> GetByIdAsync(int id);
}