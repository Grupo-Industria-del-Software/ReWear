using Application.DTOs.Catalogs;
using Application.Interfaces.Catalogs;
using Domain.Entities;

namespace API.Controllers;

public class ProductStatusController : CatalogController<ProductStatus, CatalogRequestDTO, CatalogResponseDTO>
{
    public ProductStatusController(ICatalogService<ProductStatus, CatalogRequestDTO, CatalogResponseDTO> service) :
        base(service)
    {
    }
}