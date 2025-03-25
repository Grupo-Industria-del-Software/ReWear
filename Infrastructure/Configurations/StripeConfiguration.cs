using Microsoft.Extensions.Configuration;


namespace Infrastructure.Configurations;

public static class StripeConfiguration
{
    public static void ConfigureStripe(IConfiguration configuration)
    {
        Stripe.StripeConfiguration.ApiKey = configuration["Stripe:SecretKey"];
    }
}