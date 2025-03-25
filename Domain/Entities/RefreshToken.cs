using Domain.Common;

namespace Domain.Entities;

public class RefreshToken :  Entity
{
    public string Token { get; set; } = string.Empty;
    public DateTime ExpiresOnUtc { get; set; }
    public bool IsUsed { get; set; } =  false;
    
    public int UserId { get; set; }
    public User User { get; set; } =  null!;
}