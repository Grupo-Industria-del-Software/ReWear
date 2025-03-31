using Domain.Common;

namespace Domain.Entities;

public class Chat : Entity
{
    public int SellerId { get; set; }
    public int BuyerId { get; set; }
    public DateTime CreatedAt { get; set; }
    public ICollection<Message> Messages { get; set; } = new List<Message>();
}