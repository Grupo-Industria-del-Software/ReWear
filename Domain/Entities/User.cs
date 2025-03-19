using Domain.Common;

namespace Domain.Entities;

public class User : Entity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public int RoleId { get; set; }
    public UserRoles? Role { get; set; }
    // Address
    public string PhoneNumber { get; set; }
    public string ProfilePicture { get; set; }
    public bool Active { get; set; }
    
    private User() { }
    
    public User(string firstName, string lastName, string email, string password, int roleId, string phoneNumber, string profilePicture, bool active)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Password = password;
        RoleId = roleId;
        PhoneNumber = phoneNumber;
        ProfilePicture = profilePicture;
        Active = active;
    }
}