using Domain.Common;

namespace Application.Interfaces.Catalogs
{
    public interface ICatalogRepository<T>
        where T : EntityCatalog
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T?> GetByIdAsync(int id);
        Task AddAsync(T entity);
        Task<bool> UpdateAsync(T entity);
        Task<bool> DeleteAsync(int id);
    }
}
