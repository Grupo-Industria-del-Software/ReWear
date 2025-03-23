using Domain.Common;

namespace Domain.Entities;

public class Municipality : Entity
{
    public string Name { get; set; } = string.Empty;
    public int DepartmentId { get; set; }
    public Department Department { get; set; } = null!;
}