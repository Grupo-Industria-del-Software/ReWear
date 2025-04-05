using Application.DTOs.Chats;
using Application.DTOs.Messages;

namespace Application.Interfaces.Chat;

public interface IChatService
{
    Task<ChatResponseDto> CreateChatAsync(int productId, int buyerId);
    Task<IEnumerable<ChatResponseDto>> GetChatsForUserAsync(int userId);
    Task<MessageResponseDto> SendMessageAsync(MessageRequestDto messageDto);
    Task<IEnumerable<MessageResponseDto>> GetMessagesAsync(int chatId);
}