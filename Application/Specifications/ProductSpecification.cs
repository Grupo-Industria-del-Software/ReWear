using Domain.AggregateRoots.Products;

namespace Application.Specifications;

public class ProductSpecification : BaseSpecification<Product>
{
    public ProductSpecification(
        int? sizeId = null,
        int? brandId = null,
        int? conditionId = null,
        int? categoryId = null,
        bool? isForRental = null,
        bool? isForSale = null,
        decimal? minPrice = null,
        decimal? maxPrice = null
    ) : base(p =>
        (!sizeId.HasValue || p.SizeId == sizeId) &&
        (!brandId.HasValue || p.BrandId == brandId) &&
        (!conditionId.HasValue || p.ConditionId == conditionId) &&
        (!categoryId.HasValue || p.CategoryId == categoryId) &&
        (!isForRental.HasValue || p.IsForRental == isForRental) &&
        (!isForSale.HasValue || p.IsForSale == isForSale) &&
        (!minPrice.HasValue || p.Price >= minPrice) &&
        (!maxPrice.HasValue || p.Price <= maxPrice))
    {
    }
}