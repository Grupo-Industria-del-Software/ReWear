using Application.DTOs.Products;
using Domain.AggregateRoots.Products;

namespace Application.Interfaces.Mappers;

public interface IProductMapper
{
    ProductResponseDto ToDto(Product product);
    ShortProductResponseDto ToShortDto(Product product);
}