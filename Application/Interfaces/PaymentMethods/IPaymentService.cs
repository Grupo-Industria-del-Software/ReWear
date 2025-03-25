namespace Application.Interfaces.PaymentMethods;

public interface IPaymentService
{
    Task<string> CreateCheckoutSessionAsync(int userId, decimal price);
    Task ProcessPaymentWebHookAsync(string json, string stripeSignature, string secret);
}