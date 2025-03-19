using Domain.Common;

namespace Domain.Entities
{
    public class UserRoles : Entity
    {
        public string Rol { get; set; }

        public List<User> Users { get; set; } = new();
        public UserRoles(string rol)
        {
            Rol = rol;
        }

    }
}