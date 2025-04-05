using Application.Interfaces.Message;
using Domain.AggregateRoots.Chat;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class MessageRepository : IMessageRepository
{
    private readonly AlqDbContext _context;

    public MessageRepository(AlqDbContext context)
    {
        _context = context;
    }
    
    public async Task<IEnumerable<Message>> GetMessagesByChatIdAsync(int chatId)
    {
        return await _context.Messages
            .Where(m => m.ChatId == chatId)
            .OrderBy(m => m.SentAt)
            .ToListAsync();
    }

    public async Task<Message> AddMessageAsync(Message message)
    {
        _context.Messages.Add(message);
        await _context.SaveChangesAsync();
        return message;
    }
}