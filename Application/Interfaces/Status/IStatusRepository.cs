using Domain.Common;

namespace Application.Interfaces.Status
{
    public interface IStatusRepository<T> 
        where T : EntityStatusCatalog
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T?> GetByIdAsync(int id);
        Task AddAsync(T entity);
        Task<bool> UpdateAsync(T entity);
        Task<bool> DeleteAsync(int id);
    }
}
