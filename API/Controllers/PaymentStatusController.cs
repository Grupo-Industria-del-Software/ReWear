using Application.DTOs.Status;
using Application.Interfaces.Status;
using Domain.Entities;

namespace API.Controllers
{
    public class PaymentStatusController : StatusController<PaymentStatus, StatusRequestDTO, StatusResponseDTO>
    {
        public PaymentStatusController(IStatusService<PaymentStatus, StatusRequestDTO, StatusResponseDTO> service) : base(service) { } 
    }
}
