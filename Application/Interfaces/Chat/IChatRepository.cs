namespace Application.Interfaces.Chat;

public interface IChatRepository
{
    Task<Domain.Entities.Chat?> GetChatByIdAsync(int chatId);
    Task<IEnumerable<Domain.Entities.Chat>> GetChatsForUserAsync(int userId);
    Task<Domain.Entities.Chat> CreateChatAsync(Domain.Entities.Chat chat);
}