namespace Application.DTOs.MessageDto;

public class MessageResponseDto
{
    public int Id { get; set; }
    public int ChatId { get; set; }
    public int SenderId { get; set; }
    public string Content { get; set; }
    public DateTime SentAt { get; set; }
}