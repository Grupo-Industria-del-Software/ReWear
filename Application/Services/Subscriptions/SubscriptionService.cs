using Application.DTOs.Subscriptions;
using Application.Interfaces.Subscriptions;

namespace Application.Services.Subscriptions;

public class SubscriptionService : ISubscriptionService
{
    private readonly ISubscriptionRepository _repository;

    public SubscriptionService(ISubscriptionRepository repository)
    {
        _repository = repository;
    }

    public async Task<SubscriptionResponseDto?> GetByUserIdAsync(int userId)
    {
        var subscription = await _repository.GetByUserIdAsync(userId);

        return subscription is null
            ? null
            : new SubscriptionResponseDto
            {
                UserId = subscription.UserId,
                SubscriptionId = subscription.SubscriptionId,
                PlanName = subscription.PlanName,
                Price = subscription.Price,
                StartDate = subscription.StartDate,
                EndDate = subscription.EndDate,
                IsActive = subscription.IsActive,
            };
    }

    public async Task<bool> HasActiveSubscription(int userId)
    {
        return await _repository.HasActiveSubscriptionAsync(userId);
    }
}