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
    [Authorize]
    [HttpGet]
    [ServiceFilter(typeof(SubscriptionRequirementFilter))]
    public IActionResult GetSubscriptionActive()
    {
        return Ok();
    }
}