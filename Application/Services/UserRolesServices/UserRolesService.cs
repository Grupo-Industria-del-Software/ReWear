﻿using Application.Interfaces;
using Application.DTOs.UserRolesDTO;
using Application.DTOs.UserRolesDTO.UserRolesDTO;
using Application.Interfaces.userRoles;
using Domain.Entities;

namespace Application.Services
{
    public class UserRolesService : IUserRolesService
    {
        private readonly IUserRolesRepository _userRolesRepository;

        public UserRolesService(IUserRolesRepository userRolesRepository)
        {
            _userRolesRepository = userRolesRepository;
        }

        public async Task<IEnumerable<UserRolesResponseDTO>> GetAllAsync()
        {
            var userRoles = await _userRolesRepository.GetAllAsync();
            return userRoles.Select(ur => new UserRolesResponseDTO { Id = ur.Id, Rol = ur.Rol });
        }

        public async Task<UserRolesResponseDTO?> GetByIdAsync(int id)
        {
            var userRole = await _userRolesRepository.GetByIdAsync(id);
            return userRole is null ? null : new UserRolesResponseDTO { Id = userRole.Id, Rol = userRole.Rol };
        }

        public async Task<UserRolesResponseDTO> CreateAsync(UserRolesRequestDTO dto)
        {
            var userRole = new UserRoles(dto.Rol);
            await _userRolesRepository.AddAsync(userRole);
            return new UserRolesResponseDTO { Id = userRole.Id, Rol = userRole.Rol };
        }

        public async Task<bool> UpdateAsync(int id, UserRolesRequestDTO dto)
        {
            var userRole = await _userRolesRepository.GetByIdAsync(id);

            if (userRole is null)
                return false;

            userRole.Rol = dto.Rol;

            return await _userRolesRepository.UpdateAsync(userRole);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _userRolesRepository.DeleteAsync(id);
        }
    }
}