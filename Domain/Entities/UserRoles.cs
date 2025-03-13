using Domain.Common;

namespace Domain.Entities
{
    public class UserRoles : Entity
    {
        public string Rol { get; set; }
        public UserRoles(string rol)
        {
            Rol = rol;
        }

    }
}