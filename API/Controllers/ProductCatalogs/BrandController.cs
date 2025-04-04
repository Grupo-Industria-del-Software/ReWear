using Application.DTOs.Catalogs;
using Application.Interfaces.Catalogs;
using Domain.Entities;

namespace API.Controllers.ProductCatalogs;

public class BrandController : CatalogController<Brand, CatalogRequestDto, CatalogResponseDto>
{
    public BrandController(ICatalogService<Brand, CatalogRequestDto, CatalogResponseDto> service)
        : base(service)
    {}
}