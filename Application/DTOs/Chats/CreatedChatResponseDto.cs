namespace Application.DTOs.Chats;

public class CreatedChatResponseDto
{
    public int ChatId { get; set; }
    public int ProductId { get; set; } 
    public DateTime CreatedAt { get; set; }
    public int SellerId { get; set; }
    public int BuyerId { get; set; }
}