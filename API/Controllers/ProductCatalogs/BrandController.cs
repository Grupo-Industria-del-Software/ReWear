using Application.DTOs.Catalogs;
using Application.Interfaces.Catalogs;
using Domain.Entities;

namespace API.Controllers.ProductCatalogs;

public class BrandController : CatalogController<Brand, CatalogRequestDTO, CatalogResponseDTO>
{
    public BrandController(ICatalogService<Brand, CatalogRequestDTO, CatalogResponseDTO> service)
        : base(service)
    {}
}