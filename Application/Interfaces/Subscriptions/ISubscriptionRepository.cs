using Domain.AggregateRoots.Products;
using Domain.Entities;

namespace Application.Interfaces.Subscriptions;

public interface ISubscriptionRepository
{
    Task<Subscription?> GetByUserIdAsync(int userId);
    Task AddAsync(Subscription subscription);
    Task UpdateAsync(Subscription subscription);
}