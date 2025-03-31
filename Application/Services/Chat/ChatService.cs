using Application.DTOs.ChatDto;
using Application.DTOs.MessageDto;
using Application.Interfaces.Chat;
using Application.Interfaces.Message;
using Application.Interfaces.Users;
using Domain.Entities;

namespace Application.Services.Chat;

public class ChatService : IChatService
{
    private readonly IChatRepository _chatRepository;
    private readonly IUserRepository _userRepository;
    private readonly IMessageRepository _messageRepository;

    public ChatService(IChatRepository chatRepository, IUserRepository userRepository, IMessageRepository messageRepository)
    {
        _chatRepository = chatRepository;
        _userRepository = userRepository;
        _messageRepository = messageRepository;
    }
    
    public async Task<ChatResponseDto> CreateChatAsync(int sellerId, int buyerId)
{
    var chat = new Domain.Entities.Chat()
    {
        SellerId = sellerId,
        BuyerId = buyerId,
        CreatedAt = DateTime.UtcNow
    };
    
    var createdChat = await _chatRepository.CreateChatAsync(chat);
    var buyer = await _userRepository.GetByIdAsync(buyerId);

    return new ChatResponseDto
    {
        ChatId = createdChat.Id,
        CreatedAt = createdChat.CreatedAt,
        SellerId = createdChat.SellerId,
        BuyerId = createdChat.BuyerId,
        BuyerName = $"{buyer.FirstName} {buyer.LastName}",
        BuyerImageUrl = buyer.ProfilePicture,
        Messages = new List<MessageResponseDto>()
    };
}

public async Task<IEnumerable<ChatResponseDto>> GetChatsForUserAsync(int userId)
{
    var chats = await _chatRepository.GetChatsForUserAsync(userId);
    var chatDtos = new List<ChatResponseDto>();

    foreach (var chat in chats)
    {
        // Si el usuario es vendedor, se obtiene la info del comprador y viceversa.
        int otherUserId = (chat.SellerId == userId) ? chat.BuyerId : chat.SellerId;
        var otherUser = await _userRepository.GetByIdAsync(otherUserId);

        chatDtos.Add(new ChatResponseDto
        {
            ChatId = chat.Id,
            CreatedAt = chat.CreatedAt,
            SellerId = chat.SellerId,
            BuyerId = chat.BuyerId,
            BuyerName = $"{otherUser.FirstName} {otherUser.LastName}",
            BuyerImageUrl = otherUser.ProfilePicture,
            Messages = chat.Messages.Select(m => new MessageResponseDto
            {
                Id = m.Id,
                ChatId = m.ChatId,
                SenderId = m.SenderId,
                Content = m.Content,
                SentAt = m.SentAt
            })
        });
    }

    return chatDtos;
}

public async Task<MessageResponseDto> SendMessageAsync(MessageRequestDto messageDto)
{
    var message = new Message()
    {
        ChatId = messageDto.ChatId,
        SenderId = messageDto.SenderId,
        Content = messageDto.Content,
        SentAt = DateTime.UtcNow
    };

    var addedMessage = await _messageRepository.AddMessageAsync(message);

    return new MessageResponseDto
    {
        Id = addedMessage.Id,
        ChatId = addedMessage.ChatId,
        SenderId = addedMessage.SenderId,
        Content = addedMessage.Content,
        SentAt = addedMessage.SentAt
    };
}

public async Task<IEnumerable<MessageResponseDto>> GetMessagesAsync(int chatId)
{
    var messages = await _messageRepository.GetMessagesByChatIdAsync(chatId);
    return messages.Select(m => new MessageResponseDto
    {
        Id = m.Id,
        ChatId = m.ChatId,
        SenderId = m.SenderId,
        Content = m.Content,
        SentAt = m.SentAt
    });
}
}