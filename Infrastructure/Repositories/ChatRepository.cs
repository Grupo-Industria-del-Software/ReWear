using Application.Interfaces.Chat;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class ChatRepository:IChatRepository
{
    private readonly AlqDbContext _context;

    public ChatRepository(AlqDbContext context)
    {
        _context = context;
    }
    
    public async Task<Chat> CreateChatAsync(Chat chat)
    {
        _context.Chats.Add(chat);
        await _context.SaveChangesAsync();
        return chat;
    }

    public async Task<Chat?> GetChatByIdAsync(int chatId)
    {
        return await _context.Chats
            .Include(c => c.Messages)
            .FirstOrDefaultAsync(c => c.Id == chatId);
    }

    public async Task<IEnumerable<Chat>> GetChatsForUserAsync(int userId)
    {
        return await _context.Chats
            .Include(c => c.Messages)
            .Where(c => c.SellerId == userId || c.BuyerId == userId)
            .ToListAsync();
    }
}