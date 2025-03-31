using System.Security.Claims;
using Application.Interfaces.PaymentMethods;
using Microsoft.AspNetCore.Authorization;
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
    [Authorize]
    public async Task<IActionResult> CreateCheckoutSession()
    {
        var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if(userId is null)
            return BadRequest("UserId is invalid");
        
        string checkoutUrl = await _service.CreateCheckoutSessionAsync(int.Parse(userId));
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