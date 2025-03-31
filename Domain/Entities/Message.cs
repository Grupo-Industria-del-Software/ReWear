using Domain.Common;

namespace Domain.Entities;

public class Message : Entity
{
    public int ChatId { get; set; }
    public Chat Chat { get; set; }
    public int SenderId { get; set; }
    public string Content { get; set; }
    public DateTime SentAt { get; set; }
}