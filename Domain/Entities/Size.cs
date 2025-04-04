using Domain.Common;

namespace Domain.Entities;

public class Size : EntityCatalog
{
    public List<CategorySize>? CategorySizes { get; set; }
}