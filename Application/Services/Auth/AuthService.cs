using Application.DTOs.Auth;
using Application.Interfaces.Auth;
using Application.Interfaces.Utils;
using Domain.Entities;

namespace Application.Services.Auth;

public class AuthService : IAuthService
{
    private readonly IAuthRepository _repository;
    private readonly IPasswordHasher _hasher;
    private readonly IJwtService  _jwtService;
    
    public AuthService(IAuthRepository repository, IPasswordHasher hasher, IJwtService jwtService)
    {
        _repository = repository;
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
            PhoneNumber = user.PhoneNumber.ToString(),
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
        
        var token = _jwtService.GenerateJwtToken(user);

        return new LoginResponseDto
        {
            AccessToken = token
        };
    }
}