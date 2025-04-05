namespace Application.Interfaces.Chat;

public interface IChatRepository
{
    Task<Domain.AggregateRoots.Chat.Chat?> GetChatByIdAsync(int chatId);
    Task<IEnumerable<Domain.AggregateRoots.Chat.Chat>> GetChatsForUserAsync(int userId);
    Task<Domain.AggregateRoots.Chat.Chat> CreateChatAsync(Domain.AggregateRoots.Chat.Chat chat);
    
}