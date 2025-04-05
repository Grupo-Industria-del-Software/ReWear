using Domain.Entities;

namespace Application.DTOs.RefreshTokens;

public class RefreshTokenResponseDto
{
    public int Id { get; set; }
    public string Token { get; set; } = string.Empty;
    public DateTime ExpiresOnUtc { get; set; }
    public int UserId { get; set; }
    public bool IsUsed { get; set; } =  false;
    
    public User? User { get; set; }
}