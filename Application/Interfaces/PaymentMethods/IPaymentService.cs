namespace Application.Interfaces.PaymentMethods;

public interface IPaymentService
{
    Task<string> CreateCheckoutSessionAsync(int userId);
    Task ProcessPaymentWebHookAsync(string json, string stripeSignature, string secret);
    Task CancelSubscriptionAsync(int userId);
}