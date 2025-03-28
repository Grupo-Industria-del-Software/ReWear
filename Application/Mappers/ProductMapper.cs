using Application.DTOs.Auth;
using Application.DTOs.Catalogs;
using Application.DTOs.CategoriesDTO;
using Application.DTOs.ConditionsDTOs;
using Application.DTOs.Products;
using Application.Interfaces.Mappers;
using Domain.AggregateRoots.Products;

namespace Application.Mappers;

public class ProductMapper : IProductMapper
{
    public ProductResponseDto ToDto(Product product)
    {
        return new ProductResponseDto
        {
            Id = product.Id,
            Name = product.Name,
            Description = product.Description,
            Price = product.Price,
            PricePerDay = product.PricePerDay,
            IsForSale = product.IsForSale,
            IsForRental = product.IsForRental,
            ProductImages = product.ProductImages.Select(i => new ProductImageResponseDto
            {
                ProductId = i.ProductId,
                Id = i.Id,
                ImageUrl = i.ImageUrl
            }).ToList(),
            User = product.User != null
                ? new UserResponseDTO
                {
                    Id = product.User.Id,
                    FirstName = product.User.FirstName,
                    LastName = product.User.LastName
                }
                : null,
            Category = product.Category != null
                ? new CategoryResponseDTO
                {
                    Id = product.Category.Id,
                    Name = product.Category.Name
                }
                : null,
            Condition = product.Condition != null
                ? new ConditionResponseDTO
                {
                    Id = product.Condition.Id,
                    Name = product.Condition.Name,
                }
                : null,
            Size = product.Size != null
                ? new CatalogResponseDTO
                {
                    Id = product.Size.Id,
                    Label = product.Size.Label
                }
                : null,
            Brand = product.Brand != null
                ? new CatalogResponseDTO
                {
                    Id = product.Brand.Id,
                    Label = product.Brand.Label
                }
                : null,
            ProductStatus = product.ProductStatus != null
                ? new CatalogResponseDTO
                {
                    Id = product.ProductStatus.Id,
                    Label = product.ProductStatus.Label,
                }
                : null
        };
    }
}