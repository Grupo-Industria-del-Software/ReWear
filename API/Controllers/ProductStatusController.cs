using Application.DTOs.Catalogs;
using Application.Interfaces.Catalogs;
using Domain.Entities;

namespace API.Controllers;

public class ProductStatusController : CatalogController<ProductStatus, CatalogRequestDto, CatalogResponseDto>
{
    public ProductStatusController(ICatalogService<ProductStatus, CatalogRequestDto, CatalogResponseDto> service) :
        base(service)
    {
    }
}