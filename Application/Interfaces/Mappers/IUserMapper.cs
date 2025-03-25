
using Application.DTOs.Auth;
using Domain.Entities;

namespace Application.Interfaces.Mappers
{
    public interface IUserMapper
    {
        UserResponseDTO MapToDto(User user);
    }
}
