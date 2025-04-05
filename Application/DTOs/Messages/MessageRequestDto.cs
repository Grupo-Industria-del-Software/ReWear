namespace Application.DTOs.Messages;

public class MessageRequestDto
{
    public int ChatId { get; set; }
    public int SenderId { get; set; }
    public string Content { get; set; } = string.Empty;
}
