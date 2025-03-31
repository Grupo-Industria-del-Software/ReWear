using Application.DTOs.Users;
using Application.Interfaces.Users;

namespace Application.Services.Users;

public class UserService : IUserService
{
    private readonly IUserRepository _repository;

    public UserService(IUserRepository repository)
    {
        _repository = repository;
    }
    
    public async Task<bool> UpdateUser(int id, UserRequestDto dto)
    {
        var user = await _repository.GetById(id);

        if (user == null)
        {
            return false;
        }
        
        user.FirstName = dto.FirstName ??  user.FirstName;
        user.LastName = dto.LastName  ??  user.LastName;
        user.PhoneNumber = dto.PhoneNumber   ??  user.PhoneNumber;
        user.ProfilePicture = dto.ProfilePicture  ??  user.ProfilePicture;
        
        return await _repository.UpdateAsync(user);
    }
}