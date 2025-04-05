namespace Application.DTOs.Messages;

public class MessageResponseDto
{
    public int Id { get; set; }
    public int ChatId { get; set; }
    public int SenderId { get; set; }
    public string Content { get; set; }  = string.Empty;
    public DateTime SentAt { get; set; }
}