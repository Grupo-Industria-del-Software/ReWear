using Application.DTOs.Catalogs;
using Application.Interfaces.Catalogs;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Controller]
[Route("api/Category")]
public class CategoryController : CatalogController<Category, CatalogRequestDTO, CatalogResponseDTO>
{
    public CategoryController(ICatalogService<Category, CatalogRequestDTO, CatalogResponseDTO> service)
        : base(service)
    {}
}