using Application.Interfaces.Subscriptions;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class SubscriptionRepository :  ISubscriptionRepository
{
    private readonly AlqDbContext  _context;

    public SubscriptionRepository(AlqDbContext context)
    {
        _context = context;
    }
        
    public async Task<Subscription?> GetByUserIdAsync(int userId)
    {
        return await _context.Subscriptions
            .FirstOrDefaultAsync(s => s.UserId == userId && s.IsActive);
    }

    public async Task AddAsync(Subscription subscription)
    {
        _context.Subscriptions.Add(subscription);
        await _context.SaveChangesAsync();
    }

    public Task UpdateAsync(Subscription subscription)
    {
        _context.Subscriptions.Update(subscription);
        return _context.SaveChangesAsync();
    }
}