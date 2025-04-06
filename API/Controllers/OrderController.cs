using System.Security.Claims;
using API.Filters;
using Application.DTOs.Orders;
using Application.Interfaces.Orders;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/order")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost]
        [Authorize(Roles = "Seller")]
        [ServiceFilter(typeof(SubscriptionRequirementFilter))]
        public async Task<IActionResult> CreateOrder([FromBody] OrderRequestDto request)
        {
            var hasInvalidItems = request.OrderItems.Any(item =>
                (item.RentalStart.HasValue && item.RentalEnd < item.RentalStart) ||
                (item.RentalEnd.HasValue && !item.RentalStart.HasValue));

            if (hasInvalidItems)
                return BadRequest("Combinación inválida de fechas de alquiler");

            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        
            if(userId == null)
                return Unauthorized();
            
            try
            {
                var order = await _orderService.CreateOrderAsync(int.Parse(userId),request);
                return CreatedAtAction(nameof(GetOrder), new { id = order.Id }, order);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Seller")]
        [ServiceFilter(typeof(SubscriptionRequirementFilter))]
        public async Task<IActionResult> GetOrder(int id)
        {
            try
            {
                var order = await _orderService.GetOrderByIdAsync(id);
                return Ok(order);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpGet("{orderId}/total")]
        public async Task<IActionResult> GetOrderTotal(int orderId)
        {
            try
            {
                var total = await _orderService.CalculateOrderTotalAsync(orderId);
                return Ok(total);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpPut("{orderId}/status/{statusId}")]
        public async Task<IActionResult> UpdateOrderStatus(int orderId, int statusId)
        {
            var success = await _orderService.UpdateOrderStatusAsync(orderId, statusId);
            return success ? NoContent() : NotFound();
        }

        [HttpPost("{orderId}/items")]
        [Authorize(Roles = "Seller")]
        [ServiceFilter(typeof(SubscriptionRequirementFilter))]
        public async Task<IActionResult> AddOrderItem(int orderId, [FromBody] OrderItemRequestDto item)
        {
            try
            {
                var newItem = await _orderService.AddItemToOrderAsync(orderId, item);
                return CreatedAtAction(nameof(GetOrderTotal), new { orderId }, newItem);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpDelete("{orderId}/items/{itemId}")]
        [Authorize(Roles = "Seller")]
        [ServiceFilter(typeof(SubscriptionRequirementFilter))]
        public async Task<IActionResult> RemoveOrderItem(int orderId, int itemId)
        {
            var success = await _orderService.RemoveItemFromOrderAsync(orderId, itemId);
            return success ? NoContent() : NotFound();
        }

        [HttpPut("{orderId}/items/{itemId}")]
        [Authorize(Roles = "Seller")]
        [ServiceFilter(typeof(SubscriptionRequirementFilter))]
        public async Task<IActionResult> UpdateOrderItem(
            int orderId,
            int itemId,
            [FromBody] OrderItemRequestDto request)
        {
            var success = await _orderService.UpdateOrderItemAsync(orderId, itemId, request);
            return success ? NoContent() : NotFound();
        }

    }
}
