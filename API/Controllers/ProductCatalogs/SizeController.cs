using Application.DTOs.Catalogs;
using Application.Interfaces.Catalogs;
using Domain.Entities;

namespace API.Controllers.ProductCatalogs;

public class SizeController : CatalogController<Size, CatalogRequestDTO, CatalogResponseDTO>
{
    public SizeController(ICatalogService<Size, CatalogRequestDTO, CatalogResponseDTO> service) :
        base(service)
    {
    }
}