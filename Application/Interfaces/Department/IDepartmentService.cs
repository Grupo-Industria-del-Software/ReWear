using Application.DTOs.Departments;

namespace Application.Interfaces.Department;

public interface IDepartmentService
{
    Task<IEnumerable<DepartmentResponseDto>> GetAllAsync();
    Task<DepartmentResponseDto?> GetByIdAsync(int id);
    Task<DepartmentResponseDto> CreateAsync(DepartmentRequestDto departmentRequestDto);
    Task<bool>UpdateAsync(int id, DepartmentRequestDto departmentRequestDto);
    Task<bool>DeleteAsync(int id); 
}