using Application.DTOs.Auth;
using Application.Interfaces.Users;

namespace Application.Services.Users;

public class UserService : IUserService
{
    private readonly IUserRepository _repository;

    public UserService(IUserRepository repository)
    {
        _repository = repository;
    }

    public async Task<UserResponseDTO?> GetByIdAsync(int id)
    {
        var user = await _repository.GetByIdAsync(id);
        return user is null
            ? null
            : new UserResponseDTO()
            {
                Id = user.Id, 
                FirstName = user.FirstName,
                LastName = user.LastName,
            };
    }
}