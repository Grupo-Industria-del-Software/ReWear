using Application.DTOs.Auth;
using Application.DTOs.Catalogs;
using Application.DTOs.Products;
using Application.DTOs.Users;
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
                ? new UserResponseDto
                {
                    Id = product.User.Id,
                    FirstName = product.User.FirstName,
                    LastName = product.User.LastName
                }
                : null,
            Category = product.Category != null
                ? new CatalogResponseDto()
                {
                    Id = product.Category.Id,
                    Label = product.Category.Label
                }
                : null,
            Condition = product.Condition != null
                ? new CatalogResponseDto()
                {
                    Id = product.Condition.Id,
                    Label = product.Condition.Label,
                }
                : null,
            Size = product.Size != null
                ? new CatalogResponseDto
                {
                    Id = product.Size.Id,
                    Label = product.Size.Label
                }
                : null,
            Brand = product.Brand != null
                ? new CatalogResponseDto
                {
                    Id = product.Brand.Id,
                    Label = product.Brand.Label
                }
                : null,
            ProductStatus = product.ProductStatus != null
                ? new CatalogResponseDto
                {
                    Id = product.ProductStatus.Id,
                    Label = product.ProductStatus.Label,
                }
                : null
        };
    }

    public ShortProductResponseDto ToShortDto(Product product)
    {
        return new ShortProductResponseDto
        {
            Id = product.Id,
            Name = product.Name,
            Description = product.Description,
            Category = product.Category!.Label,
            Condition = product.Condition!.Label,
            ProductStatus = product.ProductStatus!.Label,
            Size = product.Size!.Label,
            Brand = product.Brand!.Label,
            IsForRental = product.IsForRental,
            Price = product.Price,
            PricePerDay = product.PricePerDay,
            Images = product.ProductImages.Select(i => new ProductImageResponseDto
            {
                ProductId = i.ProductId,
                Id = i.Id,
                ImageUrl = i.ImageUrl
            })
        };
    }
}