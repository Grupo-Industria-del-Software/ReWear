using Microsoft.AspNetCore.Mvc;
using Application.DTOs.Catalogs;
using Application.Interfaces.Catalogs;
using Domain.Entities;

namespace API.Controllers
{
    [ApiController]
    [Route("api/condition")] 
    public class ConditionController : CatalogController<Condition, CatalogRequestDto, CatalogResponseDto>
    {
        public ConditionController(ICatalogService<Condition, CatalogRequestDto, CatalogResponseDto> service)
            : base(service)
        {}
    }
}
