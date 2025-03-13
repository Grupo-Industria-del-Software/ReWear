using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.UserRolesDTO
{
    public class UserRolesResponseDTO
    {
        public int Id { get; set; }
        public string Rol { get; set; } = string.Empty; // Inicialización
    }
}
