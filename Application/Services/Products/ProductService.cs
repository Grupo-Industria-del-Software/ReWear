using Application.DTOs.Auth;
using Application.DTOs.Catalogs;
using Application.DTOs.CategoriesDTO;
using Application.DTOs.ConditionsDTOs;
using Application.DTOs.Products;
using Application.Interfaces.Mappers;
using Application.Interfaces.Products;
using Domain.AggregateRoots.Products;

namespace Application.Services.Products;

public class ProductService : IProductService
{
    private readonly IProductRepository _repository;
    private readonly IProductMapper _mapper;

    public ProductService(IProductRepository repository,  IProductMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    
    public async Task<IEnumerable<ProductResponseDto>> GetAllAsync()
    {
        var products = await _repository.GetAllAsync();
        return products.Select(p => _mapper.ToDto(p)).ToList();
    }

    public async Task<ProductResponseDto?> GetByIdAsync(int id)
    {
        var product = await _repository.GetByIdAsync(id);
        return product is null ? null : _mapper.ToDto(product);
    }

    public async Task<ProductResponseDto> CreateAsync(ProductRequestDto dto)
    {
        if (dto == null)
            throw new ArgumentNullException(nameof(dto), "El producto no puede ser nulo.");
        
        var product = new Product
        {
            UserId = dto.UserId,
            CategoryId = dto.CategoryId,
            ConditionId = dto.ConditionId,
            SizeId = dto.SizeId,
            BrandId = dto.BrandId,
            ProductStatusId = dto.ProductStatusId,
            Name = dto.Name,
            Description = dto.Description,
            IsForSale = dto.IsForSale,
            IsForRental = dto.IsForRental,
            Price = dto.Price,
            PricePerDay = dto.PricePerDay,
            ProductImages = dto.ProductImages.Select(i => new ProductImage
            {
                ImageUrl = i.ImageUrl,
            }).ToList()
        };
        
        await _repository.AddAsync(product);
        return _mapper.ToDto(product);
    }

    public async Task<bool> UpdateAsync(int id, ProductRequestDto dto)
    {
        var product = await _repository.GetByIdAsync(id);
        if  (product == null) return false;
        
        product.BrandId = dto.BrandId;
        product.CategoryId = dto.CategoryId;
        product.ConditionId = dto.ConditionId;
        product.SizeId = dto.SizeId;
        product.Name = dto.Name;
        product.Description = dto.Description;
        product.IsForSale = dto.IsForSale;
        product.IsForRental = dto.IsForRental;
        product.Price = dto.Price;
        product.PricePerDay = dto.PricePerDay;
        
        product.ProductImages.Clear();
        product.ProductImages.AddRange(dto.ProductImages.Select(i => new ProductImage
        {
            ImageUrl = i.ImageUrl,
        }));
        
        return await _repository.UpdateAsync(product);
    }


    public Task<bool> DeleteAsync(int id)
    {
        return _repository.DeleteAsync(id);
    }
}