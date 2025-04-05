using Domain.AggregateRoots.Products;
using Domain.Common;

namespace Domain.AggregateRoots.Chat;

public class Chat:AggregateRoot
{
    public int SellerId { get; set; }
    public int BuyerId { get; set; }
    public int ProductId { get; set; }
    public Product Product { get; set; }
    public DateTime CreatedAt { get; set; }
    public ICollection<Message> Messages { get; set; } = new List<Message>();
}