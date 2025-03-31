using Application.DTOs.ChatDto;
using Application.DTOs.MessageDto;

namespace Application.Interfaces.Chat;

public interface IChatService
{
    Task<ChatResponseDto> CreateChatAsync(int sellerId, int buyerId);
    Task<IEnumerable<ChatResponseDto>> GetChatsForUserAsync(int userId);
    Task<MessageResponseDto> SendMessageAsync(MessageRequestDto messageDto);
    Task<IEnumerable<MessageResponseDto>> GetMessagesAsync(int chatId);
}