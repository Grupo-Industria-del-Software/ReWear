using Application.DTOs.Users;
using Application.DTOs.Auth;

namespace Application.Interfaces.Users;

public interface IUserService
{
    Task<bool> UpdateUser(int id, UserRequestDto dto);
    Task<UserResponseDto?> GetByIdAsync(int id);
    Task<IEnumerable<UserResponseDto>> GetAllAsync(); 
    Task<bool> ChangeUserStatusAsync(int id, bool active); 
}