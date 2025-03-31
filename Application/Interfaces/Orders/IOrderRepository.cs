using Domain.AggregateRoots.Orders;


namespace Application.Interfaces.Orders
{
    public interface IOrderRepository
    {
        Task<Order?> GetByIdAsync(int orderId);
        Task AddAsync(Order order);
        Task UpdateAsync(Order order);
        Task DeleteAsync(Order order);
        Task<IEnumerable<Order>> GetByFiltersAsync(int? customerId = null, int? providerId = null);
    }
}
