using Application.DTOs.Catalogs;
using Application.Interfaces.Catalogs;
using Domain.Entities;

namespace API.Controllers
{
    public class RentalApplicationStatusController : CatalogController<RentalApplicationStatus, CatalogRequestDTO, CatalogResponseDTO>
    {
        public RentalApplicationStatusController(ICatalogService<RentalApplicationStatus, CatalogRequestDTO, CatalogResponseDTO> service) :
        base(service)
        {
        }
    }
}
