namespace Application.Interfaces.Message;

public interface IMessageRepository
{
    Task<IEnumerable<Domain.Entities.Message>> GetMessagesByChatIdAsync(int chatId);
    Task<Domain.Entities.Message> AddMessageAsync(Domain.Entities.Message message);
}