using Domain.Entities;

namespace Application.Interfaces
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