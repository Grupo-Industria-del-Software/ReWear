using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Catalogs
{
    public class CatalogResponseDto
    {
        public int Id { get; set; }
        public string Label { get; set; } = string.Empty;
        public bool IsActive { get; set; }
    }
}
