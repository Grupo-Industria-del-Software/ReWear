using Domain.Common;

namespace Domain.AggregateRoots.Chat;

public class Message:AggregateRoot
{
    public int ChatId { get; set; }
    public Chat Chat { get; set; }
    public int SenderId { get; set; }
    public string Content { get; set; }
    public DateTime SentAt { get; set; }
}