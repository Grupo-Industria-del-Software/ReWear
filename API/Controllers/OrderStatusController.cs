using Application.DTOs.Catalogs;
using Application.Interfaces.Catalogs;
using Domain.Entities;

namespace API.Controllers
{
    public class OrderStatusController : CatalogController<OrderStatus, CatalogRequestDTO, CatalogResponseDTO>
    {
        public OrderStatusController(ICatalogService<OrderStatus, CatalogRequestDTO, CatalogResponseDTO> service) : base(service) { }
    }
}
