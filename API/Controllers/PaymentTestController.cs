using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PaymentTestController : ControllerBase
{
    [HttpGet("/complete")]
    public IActionResult Complete()
    {
        return Ok("Pago completado");
    }
    
    [HttpGet("/calcel")]
    public IActionResult Cancel()
    {
        return Ok("No tito, no hay varo");
    }
}