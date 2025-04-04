
namespace Domain.Entities;

public class CategorySize
{
    public int CategoryId { get; set; }
    public required Category Category { get; set; }
    
    public int SizeId { get; set; }
    public required Size Size { get; set; }
}