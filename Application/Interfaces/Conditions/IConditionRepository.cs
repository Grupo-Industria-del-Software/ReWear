using Domain.Entities;

namespace Application.Interfaces.Conditions
{
    public interface IConditionRepository
    {
        Task<IEnumerable<Condition>> GetAllAsync();
        Task<Condition?> GetByIdAsync(int id);
        Task AddAsync(Condition condition);
        Task<bool> UpdateAsync(Condition condition);
        Task<bool> DeleteAsync(int id);
    }
}
