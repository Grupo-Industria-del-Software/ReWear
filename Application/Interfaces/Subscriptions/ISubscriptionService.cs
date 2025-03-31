
namespace Application.Interfaces.Subscriptions;

public interface ISubscriptionService
{
    Task<bool> HasActiveSubscription(int userId);
}