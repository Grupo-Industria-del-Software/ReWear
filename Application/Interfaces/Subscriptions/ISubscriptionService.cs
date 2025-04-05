
using Application.DTOs.Subscriptions;

namespace Application.Interfaces.Subscriptions;

public interface ISubscriptionService
{
    Task<SubscriptionResponseDto?> GetByUserIdAsync(int userId);
    Task<bool> HasActiveSubscription(int userId);
}