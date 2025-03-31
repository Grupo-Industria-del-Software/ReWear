namespace Application.DTOs.Products;

public class ProductImageResponseDto
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public string ImageUrl { get; set; } =  string.Empty;
    
    public string PublicId { get; set; } =  string.Empty; 
}