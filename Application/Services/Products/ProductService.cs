using Application.DTOs.Products;
using Application.Interfaces.Mappers;
using Application.Interfaces.Products;
using Application.Specifications;
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
    
    public async Task<IEnumerable<ProductResponseDto>> GetAllAsync(ProductFilterDto filterDto)
    {
        var spec = new ProductSpecification
        (
            filterDto.SizeId,
            filterDto.BrandId,
            filterDto.ConditionId,
            filterDto.CategoryId,
            filterDto.IsForRental,
            filterDto.IsForSale,
            filterDto.MinPrice,
            filterDto.MaxPrice
        );
        
        var products = await _repository.GetAllAsync(spec);
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

    public async Task<bool> UpdateAsync(int id, ProductUpdateRequestDto dto)
    {
        var product = await _repository.GetByIdAsync(id);
        if (product == null) return false;
        
        product.CategoryId = dto.CategoryId ?? product.CategoryId;
        product.ConditionId = dto.ConditionId ?? product.ConditionId;
        product.SizeId = dto.SizeId ?? product.SizeId;
        product.BrandId = dto.BrandId ?? product.BrandId;
        product.Name = string.IsNullOrWhiteSpace(dto.Name) ? product.Name : dto.Name;
        product.Description = string.IsNullOrWhiteSpace(dto.Description) ? product.Description : dto.Description;
        product.Price = dto.Price ?? product.Price;
        product.PricePerDay = dto.PricePerDay ?? product.PricePerDay;
        product.IsForSale = dto.IsForSale ?? product.IsForSale;
        product.IsForRental = dto.IsForRental ?? product.IsForRental;
        
        if (dto.ProductImages != null && dto.ProductImages.Any())
        {
            product.ProductImages.Clear();
            product.ProductImages.AddRange(dto.ProductImages.Select(i => new ProductImage
            {
                ImageUrl = i.ImageUrl
            }));
        }

        return await _repository.UpdateAsync(product);
    }


    public Task<bool> DeleteAsync(int id)
    {
        return _repository.DeleteAsync(id);
    }

}