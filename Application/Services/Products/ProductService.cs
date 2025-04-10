using Application.DTOs.Products;
using Application.Interfaces.Cloudinary;
using Application.Interfaces.Mappers;
using Application.Interfaces.Products;
using Application.Specifications;
using Domain.AggregateRoots.Products;
using Microsoft.AspNetCore.Http;

namespace Application.Services.Products;

public class ProductService : IProductService
{
    private readonly IProductRepository _repository;
    private readonly IProductMapper _mapper;
    private readonly ICloudinaryService _cloudinaryService;

    public ProductService(IProductRepository repository,  IProductMapper mapper, ICloudinaryService cloudinaryService)
    {
        _repository = repository;
        _mapper = mapper;
        _cloudinaryService = cloudinaryService;
    }
    
    public async Task<IEnumerable<ShortProductResponseDto>> GetAllAsync(ProductFilterDto filterDto)
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
        return products.Select(p => _mapper.ToShortDto(p)).ToList();
    }

    public async Task<IEnumerable<ShortProductResponseDto>> GetAllByUserIdAsync(ProductFilterDto filterDto, int userId)
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
        
        var products = await _repository.GetAllByUserIdAsync(userId,spec);
        return products.Select(p => _mapper.ToShortDto(p)).ToList();
    }

    public async Task<ProductResponseDto?> GetByIdAsync(int id)
    {
        var product = await _repository.GetByIdAsync(id);
        return product is null ? null : _mapper.ToDto(product);
    }

    public async Task<ProductResponseDto> CreateAsync(int userId, ProductRequestDto dto, List<IFormFile> images)
    {
        if (dto == null)
            throw new ArgumentNullException(nameof(dto), "El producto no puede ser nulo.");
        
        var product = new Product
        {
            UserId = userId,
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
            
        };
        
        await _repository.AddAsync(product);
    
        foreach (var imgFile in images)
        {
            if (imgFile != null && imgFile.Length > 0)
            {
                var tempFilePath = Path.GetTempFileName();
                using (var stream = new FileStream(tempFilePath, FileMode.Create))
                {
                    await imgFile.CopyToAsync(stream);
                }

                var uploadResult = await _cloudinaryService.UploadImageAsync(tempFilePath);

                product.ProductImages.Add(new ProductImage
                {
                    ProductId = product.Id,
                    ImageUrl = uploadResult.Url,
                    PublicId = uploadResult.PublicId,
                });

                File.Delete(tempFilePath);
            }
        }

        await _repository.UpdateAsync(product);
        return _mapper.ToDto(product);
    }

    public async Task<bool> UpdateAsync(int id, ProductUpdateRequestDto dto, List<IFormFile> images)
{
    var product = await _repository.GetByIdAsync(id);
    if (product == null) return false;

    // Actualización de campos básicos
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

    // Si hay nuevas imágenes, eliminar las antiguas y subir nuevas
    if (images != null && images.Any())
    {
        foreach (var existingImg in product.ProductImages)
        {
            await _cloudinaryService.DeleteImageAsync(existingImg.PublicId);
        }

        product.ProductImages.Clear();

        foreach (var imgFile in images)
        {
            if (imgFile != null && imgFile.Length > 0)
            {
                var tempFilePath = Path.GetTempFileName();
                try
                {
                    using (var stream = new FileStream(tempFilePath, FileMode.Create))
                    {
                        await imgFile.CopyToAsync(stream);
                    }

                    var uploadResult = await _cloudinaryService.UploadImageAsync(tempFilePath);

                    product.ProductImages.Add(new ProductImage
                    {
                        ProductId = product.Id,
                        ImageUrl = uploadResult.Url,
                        PublicId = uploadResult.PublicId,
                    });
                }
                finally
                {
                    if (File.Exists(tempFilePath))
                        File.Delete(tempFilePath);
                }
            }
        }
    }

    return await _repository.UpdateAsync(product);
}


    public async Task<bool> DeleteAsync(int id)
    {
        var product = await _repository.GetByIdAsync(id);
        if (product == null) return false;
        
        foreach (var img in product.ProductImages)
        {
            await _cloudinaryService.DeleteImageAsync(img.PublicId);
        }
    
        return await _repository.DeleteAsync(id);
    }

    public async Task<bool> DeleteImageOfProductAsync(int imageId)
    {
        return await _repository.DeleteImageOfProductAsync(imageId);
    }
}