namespace Application.Interfaces.Message;

public interface IMessageRepository
{
    Task<IEnumerable<Domain.AggregateRoots.Chat.Message>> GetMessagesByChatIdAsync(int chatId);
    Task<Domain.AggregateRoots.Chat.Message> AddMessageAsync(Domain.AggregateRoots.Chat.Message message);
}