using Application.DTOs.Messages;

namespace Application.DTOs.Chats;

public class ChatResponseDto
{
    public int ChatId { get; set; }
    
    public int ProductId { get; set; } 
    public DateTime CreatedAt { get; set; }
    public int SellerId { get; set; }
    public int BuyerId { get; set; }
    public string BuyerName { get; set; } = string.Empty;
    public string BuyerImageUrl { get; set; } = string.Empty;
    public IEnumerable<MessageResponseDto>? Messages { get; set; }
}