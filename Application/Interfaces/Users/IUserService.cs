using Application.DTOs.Users;
using Application.DTOs.Auth;
using Microsoft.AspNetCore.Http;

namespace Application.Interfaces.Users;

public interface IUserService
{
    Task<bool> UpdateUser(int id, UserRequestDto dto);
    Task<UserProfileResponseDto?> GetByIdAsync(int id);
    Task<IEnumerable<UserResponseDto>> GetAllAsync(); 
    Task<bool> ChangeUserStatusAsync(int id, bool active); 
    Task<bool> UpdateProfilePictureAsync(int userId, IFormFile? profilePicture);
}