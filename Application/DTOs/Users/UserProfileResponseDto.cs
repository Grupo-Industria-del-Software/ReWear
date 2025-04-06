using Application.DTOs.Subscriptions;
using Application.DTOs.UserRoles;

namespace Application.DTOs.Users;

public class UserProfileResponseDto
{
    public int Id { get; set; }
    public string FirstName { get; set; }  = string.Empty;
    public string LastName { get; set; }   = string.Empty;
    public string Email { get; set; }  = string.Empty;
    public string PhoneNumber { get; set; }  = string.Empty;
    public string ProfilePicture { get; set; }  = string.Empty;
    public required UserRolesResponseDto UserRole { get; set; }
}