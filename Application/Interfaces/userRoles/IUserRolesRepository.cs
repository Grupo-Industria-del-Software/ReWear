using Domain.Entities;

namespace Application.Interfaces.userRoles
{
    public interface IUserRolesRepository
    {
        Task<IEnumerable<UserRoles>> GetAllAsync();
        Task<UserRoles?> GetByIdAsync(int id);
        Task AddAsync(UserRoles rol);
        Task<bool> UpdateAsync(UserRoles rol);
        Task<bool> DeleteAsync(int id);

    }
}