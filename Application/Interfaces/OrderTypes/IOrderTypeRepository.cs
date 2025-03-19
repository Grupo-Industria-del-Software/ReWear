using Domain.Entities;

namespace Application.Interfaces.OrderTypes
{
    public interface IOrderTypeRepository
    {
        Task<IEnumerable<OrderType>> GetAllAsync();
        Task<OrderType?> GetByIdAsync(int id);
        Task AddAsync(OrderType orderType);
        Task<bool> UpdateAsync(OrderType orderType);
        Task<bool> DeleteAsync(int id);
    }
}