using Application.DTOs.UserRoles;

namespace Application.Interfaces.userRoles
{
    public interface IUserRolesService
    {

        Task<IEnumerable<UserRolesResponseDto>> GetAllAsync();

        Task<UserRolesResponseDto?> GetByIdAsync(int id);

        Task<UserRolesResponseDto> CreateAsync(UserRolesRequestDto dto);

        Task<bool> UpdateAsync(int id, UserRolesRequestDto dto);

        Task<bool> DeleteAsync(int id);
    }
}
