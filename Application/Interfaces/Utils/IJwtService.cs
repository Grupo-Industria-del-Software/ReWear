using Domain.Entities;

namespace Application.Interfaces.Utils;

public interface IJwtService
{
    public string GenerateJwtToken(User user);
}