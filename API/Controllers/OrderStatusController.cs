using Application.DTOs.Catalogs;
using Application.Interfaces.Catalogs;
using Domain.Entities;

namespace API.Controllers
{
    public class OrderStatusController : CatalogController<OrderStatus, CatalogRequestDto, CatalogResponseDto>
    {
        public OrderStatusController(ICatalogService<OrderStatus, CatalogRequestDto, CatalogResponseDto> service) : base(service) { }
    }
}
