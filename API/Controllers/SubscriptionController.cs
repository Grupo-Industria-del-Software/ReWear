using System.Security.Claims;
using API.Filters;
using Application.Interfaces.Subscriptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SubscriptionController : ControllerBase
{
    private readonly ISubscriptionService _subscriptionService;

    public SubscriptionController(ISubscriptionService subscriptionService)
    {
        _subscriptionService = subscriptionService;
    }
    
    [Authorize]
    [HttpGet]
    [ServiceFilter(typeof(SubscriptionRequirementFilter))]
    public IActionResult GetSubscriptionActive()
    {
        return Ok();
    }

    [Authorize(Roles = "Seller")]
    [HttpGet("info")]
    public async Task<IActionResult> GetSubscriptionByUserId()
    {
        var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        
        if(userId == null)
            return Unauthorized();
        
        var subscription = await _subscriptionService.GetByUserIdAsync(int.Parse(userId));
        return subscription == null ? NotFound() : Ok(subscription);
    }
}