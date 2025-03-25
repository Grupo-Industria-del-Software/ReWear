namespace Application.DTOs.RefreshTokens;

public class RefreshTokenRequestDto
{
    public DateTime ExpiresOnUtc { get; set; }
    public int UserId { get; set; }
}