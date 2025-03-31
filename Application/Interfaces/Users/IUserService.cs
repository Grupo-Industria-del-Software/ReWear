using Application.DTOs.Users;

namespace Application.Interfaces.Users;

public interface IUserService
{
    Task<bool> UpdateUser(int id, UserRequestDto dto);
}