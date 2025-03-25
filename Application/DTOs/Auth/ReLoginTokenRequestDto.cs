namespace Application.DTOs.Auth;

public class ReLoginTokenRequestDto
{
    public string RefreshToken { get; set; } = string.Empty;
}