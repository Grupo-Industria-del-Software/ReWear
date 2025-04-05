using Application.DTOs.Users;
using Application.Interfaces.Users;
using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Services.Users
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<bool> UpdateUser(int id, UserRequestDto dto)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null)
                return false;


            user.FirstName = dto.FirstName ?? user.FirstName;
            user.LastName = dto.LastName ?? user.LastName;
            user.PhoneNumber = dto.PhoneNumber ?? user.PhoneNumber;
            user.ProfilePicture = dto.ProfilePicture ?? user.ProfilePicture;

            return await _userRepository.UpdateAsync(user);
        }

        public async Task<IEnumerable<UserResponseDto>> GetAllAsync()
        {
            var users = await _userRepository.GetAllAsync();

            return users.Select(user => new UserResponseDto
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                RoleId = user.RoleId,
                Active = user.Active // 
            }).ToList();
        }
        public async Task<UserResponseDto?> GetByIdAsync(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null)
                return null;

            return new UserResponseDto
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                RoleId = user.RoleId,
                Active = user.Active //
            };
        }

        public async Task<bool> ChangeUserStatusAsync(int id, bool active)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null)
                return false;

            user.Active = active; // 
            return await _userRepository.UpdateAsync(user); // 
        }
    }
}