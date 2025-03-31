using Application.Interfaces.Subscriptions;

namespace Application.Services.Subscriptions;

public class SubscriptionService : ISubscriptionService
{
    private readonly ISubscriptionRepository _repository;

    public SubscriptionService(ISubscriptionRepository repository)
    {
        _repository = repository;
    }
    
    public async Task<bool> HasActiveSubscription(int userId)
    {
        return await _repository.HasActiveSubscriptionAsync(userId);
    }
}