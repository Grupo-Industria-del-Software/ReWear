using Application.Interfaces.PaymentMethods;
using Application.Interfaces.Subscriptions;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Stripe;
using Stripe.Checkout;
using Subscription = Domain.Entities.Subscription;

namespace Infrastructure.Payments;

public class StripePaymentService : IPaymentService
{
    private readonly ISubscriptionRepository _repository;
    private readonly IConfiguration  _configuration;
    
    public StripePaymentService(ISubscriptionRepository repository, IConfiguration configuration)
    {
        _repository = repository;
        _configuration = configuration;
    }
    
    public async Task<string> CreateCheckoutSessionAsync(int userId)
    {
        var options = new SessionCreateOptions
        {
            PaymentMethodTypes = new List<string> { "card" },
            LineItems = new List<SessionLineItemOptions>
            {
                new()
                {
                    Price = _configuration["Stripe:PriceId"], 
                    Quantity = 1
                }
            },
            Mode = "subscription",
            SuccessUrl = "https://www.youtube.com", 
            CancelUrl = "https://www.google.com",
            ClientReferenceId = userId.ToString()
        };

        var service = new SessionService();
        Session session = await service.CreateAsync(options);

        return session.Url;
    }

    public async Task ProcessPaymentWebHookAsync(string json, string stripeSignature, string secret)
    {
        var webhookSecret = _configuration["Stripe:WebhookSecret"];

        try
        {
            var stripeEvent = EventUtility.ConstructEvent(json, stripeSignature, webhookSecret);

            if (stripeEvent?.Type == "checkout.session.completed")
            {
                var session = stripeEvent.Data.Object as Session;
                if (session?.ClientReferenceId == null)
                {
                    Console.WriteLine("Webhook recibido sin ClientReferenceId");
                    return;
                }

                int userId = int.Parse(session.ClientReferenceId);

                var service = new SessionService();
                session = await service.GetAsync(session.Id, new SessionGetOptions { Expand = new List<string> { "line_items" } });

                var lineItem = session.LineItems?.Data?.FirstOrDefault();
                if (lineItem == null)
                {
                    Console.WriteLine("Webhook recibido sin items en la sesión");
                    return;
                }

                var planName = lineItem.Description ?? "Unknown Plan";
                var price = lineItem.AmountTotal / 100m;

                var subscription = new Subscription
                {
                    UserId = userId,
                    PlanName = planName,
                    Price = price,
                    StartDate = DateTime.UtcNow,
                    EndDate = DateTime.UtcNow.AddMonths(1),
                    IsActive = true
                };
                await _repository.AddAsync(subscription);
            
                Console.WriteLine($"Suscripción creada para el usuario {userId} con el plan {planName}.");
            }
        }
        catch (StripeException ex)
        {
            Console.WriteLine($"Error en Stripe Webhook: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error procesando webhook: {ex.Message}");
        }
    }
}