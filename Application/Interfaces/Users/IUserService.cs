using Application.DTOs.Users;

using Application.DTOs.Auth;

namespace Application.Interfaces.Users;

public interface IUserService
{
    Task<List<UserResponseDTO>> GetAllUsers();
    Task<bool> ChageState(int userId);
    Task<bool> UpdateUser(int id, UserRequestDto dto);
    Task<UserResponseDTO?> GetByIdAsync(int id);
}