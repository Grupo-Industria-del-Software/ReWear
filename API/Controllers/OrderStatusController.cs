using Application.DTOs.Status;
using Application.Interfaces.Status;
using Domain.Entities;

namespace API.Controllers
{
    public class OrderStatusController : StatusController<OrderStatus, StatusRequestDTO, StatusResponseDTO>
    {
        public OrderStatusController(IStatusService<OrderStatus, StatusRequestDTO, StatusResponseDTO> service) : base(service) { }
    }
}
