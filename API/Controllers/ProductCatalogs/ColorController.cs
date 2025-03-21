using Application.DTOs.Catalogs;
using Application.Interfaces.Catalogs;
using Domain.Entities;

namespace API.Controllers.ProductCatalogs;

public class ColorController : CatalogController<Color, CatalogRequestDTO, CatalogResponseDTO>
{
    public ColorController(ICatalogService<Color, CatalogRequestDTO, CatalogResponseDTO> service):
        base(service)
    {}
}