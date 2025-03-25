using Application.DTOs.Auth;
using Application.Interfaces.Mappers;
using Domain.Entities;

namespace Application.Mappers
{
    public class UserMapper : IUserMapper
    {
        public UserResponseDTO MapToDto(User user)
        {
            if (user == null) return null;

            return new UserResponseDTO
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName
            };
        }
    }
}
