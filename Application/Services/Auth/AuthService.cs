using Application.DTOs.Auth;
using Application.DTOs.RefreshTokens;
using Application.Interfaces.Auth;
using Application.Interfaces.RefreshTokens;
using Application.Interfaces.Users;
using Application.Interfaces.Utils;
using Domain.Entities;

namespace Application.Services.Auth;

public class AuthService : IAuthService
{
    private readonly IUserRepository _repository;
    private readonly IRefreshTokenService _refreshTokenService;
    private readonly IPasswordHasher _hasher;
    private readonly IJwtService  _jwtService;
    
    public AuthService(IUserRepository repository, IPasswordHasher hasher, IJwtService jwtService,  IRefreshTokenService refreshTokenService)
    {
        _repository = repository;
        _refreshTokenService = refreshTokenService;
        _hasher = hasher;
        _jwtService = jwtService;
    }
    
    public async Task<RegisterResponseDto> RegisterAsync(RegisterRequestDto registerRequestDto)
    {
        var newPass = _hasher.HashPassword(registerRequestDto.Password);
        
        var user = new User(
            registerRequestDto.FirstName, 
            registerRequestDto.LastName, 
            registerRequestDto.Email,
            newPass,
            registerRequestDto.RoleId,
            registerRequestDto.PhoneNumber,
            registerRequestDto.ProfilePicture,
            true
        );
        
        await _repository.AddAsync(user);

        return new RegisterResponseDto
        {
            Id = user.Id,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Email = user.Email,
            PhoneNumber = user.PhoneNumber,
            RoleId = user.RoleId,
        };
    }

    public async Task<LoginResponseDto?> LoginAsync(LoginRequestDto loginRequestDto)
    {
        var user = await _repository.GetByEmail(loginRequestDto.Email);

        if (user is null || !_hasher.VerifyPassword(user.Password, loginRequestDto.Password))
        {
            return null;
        } 
        
        var accessToken = _jwtService.GenerateJwtToken(user);
        var rfDto = new RefreshTokenRequestDto
        {
            ExpiresOnUtc = DateTime.UtcNow.AddDays(7),
            UserId = user.Id,
        };
        
        var refreshToken = await _refreshTokenService.CreateAndAddAsync(rfDto);
        
        return new LoginResponseDto
        {
            AccessToken = accessToken,
            RefreshToken = refreshToken.Token,
        };
    }

    public async Task<LoginResponseDto?> RefreshTokenAsync(ReLoginTokenRequestDto refreshTokenRequestDto)
    {
        var refreshToken = await _refreshTokenService.GetByRefreshTokenAsync(refreshTokenRequestDto.RefreshToken);

        if (refreshToken is null || refreshToken.ExpiresOnUtc < DateTime.UtcNow || refreshToken.IsUsed)
        {
            return null;
        }
        // Falta marcar refresh token como usado

        var newRtDto = new RefreshTokenRequestDto
        {
            ExpiresOnUtc = DateTime.UtcNow.AddDays(7),
            UserId = refreshToken.UserId
        };
        
        var newAccessToken = _jwtService.GenerateJwtToken(refreshToken.User);
        var newRefreshToken = await _refreshTokenService.CreateAndAddAsync(newRtDto);

        return new LoginResponseDto
        {
            AccessToken = newAccessToken,
            RefreshToken = newRefreshToken.Token
        };
    }
    
}