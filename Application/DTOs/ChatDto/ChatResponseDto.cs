using Application.DTOs.MessageDto;

namespace Application.DTOs.ChatDto;

public class ChatResponseDto
{
    public int ChatId { get; set; }
    public DateTime CreatedAt { get; set; }
    public int SellerId { get; set; }
    public int BuyerId { get; set; }
    public string BuyerName { get; set; }
    public string BuyerImageUrl { get; set; }
    public IEnumerable<MessageResponseDto> Messages { get; set; }
}