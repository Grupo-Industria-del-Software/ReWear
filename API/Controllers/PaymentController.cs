using Application.DTOs.Subscriptions;
using Application.Interfaces.PaymentMethods;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;
[ApiController]
[Route("api/[controller]")]
public class PaymentController : ControllerBase
{
    private readonly IPaymentService _service;
    private readonly IConfiguration _configuration;

    public PaymentController(IPaymentService service,  IConfiguration configuration)
    {
        _service = service;
        _configuration = configuration;
    }
    
    [HttpPost("create-checkout-session")]
    public async Task<IActionResult> CreateCheckoutSession([FromBody] CreateCheckSessionDto dto)
    {
        if(dto.UserId < 0)
            return BadRequest("UserId is invalid");
        
        string checkoutUrl = await _service.CreateCheckoutSessionAsync(dto.UserId, 10.00m);
        return Ok(new { url = checkoutUrl });
    }
    
    [HttpPost("webhook")]
    public async Task<IActionResult> Webhook([FromHeader(Name = "Stripe-Signature")] string stripeSignature)
    {
        using var reader = new StreamReader(Request.Body);
        var json = await reader.ReadToEndAsync();
        
        var secretKey = _configuration["Stripe:WebhookSecret"];
        
        try
        {
            await _service.ProcessPaymentWebHookAsync(json, stripeSignature, secretKey);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest($"Webhook Error: {ex.Message}");
        }
    }
}