using Domain.Common;

namespace Domain.Entities;

public class Department : Entity
{
    public string DepartmentName { get; set; }
    public List<Municipality> municipalities { get; set; }
    public Department(string departmentName)
    {
        DepartmentName = departmentName;
    }
    
}