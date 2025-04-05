using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Application.Interfaces.Subscriptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace API.Filters;

public class SubscriptionRequirementFilter : IAsyncAuthorizationFilter
{
    private readonly ISubscriptionService _subscriptionService;

    public SubscriptionRequirementFilter(ISubscriptionService subscriptionService)
    {
        _subscriptionService = subscriptionService;
    }
    
    public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
    {
        var userClaims = context.HttpContext.User;

        if (!userClaims.Identity?.IsAuthenticated ?? false)
        {
            context.Result = new UnauthorizedResult();
            return;
        }
        
        var userId = userClaims.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? 
                     userClaims.FindFirst(JwtRegisteredClaimNames.Sub)?.Value;

        var role = userClaims.FindFirst(ClaimTypes.Role)?.Value ?? 
                   userClaims.FindFirst("role")?.Value;

        if (string.IsNullOrEmpty(userId))
        {
            context.Result = new BadRequestResult();
            return;
        }
        
        if (role == "Seller")
        {
            var subsActive = await _subscriptionService.HasActiveSubscription(int.Parse(userId));
            
            if (!subsActive)
            {
                context.Result = new StatusCodeResult(402);
            }
        }
    }
}