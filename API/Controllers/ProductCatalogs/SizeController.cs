using Application.DTOs.Catalogs;
using Application.Interfaces.Catalogs;
using Domain.Entities;

namespace API.Controllers.ProductCatalogs;

public class SizeController : CatalogController<Size, CatalogRequestDto, CatalogResponseDto>
{
    public SizeController(ICatalogService<Size, CatalogRequestDto, CatalogResponseDto> service) :
        base(service)
    {
    }
}