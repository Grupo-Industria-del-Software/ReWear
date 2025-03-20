using Application.DTOs.Catalogs;
using Application.Interfaces.Catalogs;
using Domain.Entities;

namespace API.Controllers
{
    public class PaymentStatusController : CatalogController<PaymentStatus, CatalogRequestDTO, CatalogResponseDTO>
    {
        public PaymentStatusController(ICatalogService<PaymentStatus, CatalogRequestDTO, CatalogResponseDTO> service) : base(service) { } 
    }
}
