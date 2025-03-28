﻿using Application.DTOs.UserRolesDTO;
using Application.DTOs.UserRolesDTO.UserRolesDTO;

namespace Application.Interfaces.userRoles
{
    public interface IUserRolesService
    {

        Task<IEnumerable<UserRolesResponseDTO>> GetAllAsync();

        Task<UserRolesResponseDTO?> GetByIdAsync(int id);

        Task<UserRolesResponseDTO> CreateAsync(UserRolesRequestDTO dto);

        Task<bool> UpdateAsync(int id, UserRolesRequestDTO dto);

        Task<bool> DeleteAsync(int id);
    }
}
