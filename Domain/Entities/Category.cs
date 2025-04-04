using Domain.Common;

namespace Domain.Entities;

public class Category : EntityCatalog
{
    public List<CategorySize>? CategorySizes { get; set; }
}