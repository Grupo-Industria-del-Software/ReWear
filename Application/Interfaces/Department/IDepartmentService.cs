using Application.DTOs.DepartmentDTO;

namespace Application.Interfaces.Department;

public interface IDepartmentService
{
    Task<IEnumerable<DepartmentResponseDTO>> GetAllAsync();
    Task<DepartmentResponseDTO?> GetByIdAsync(int id);
    Task<DepartmentResponseDTO> CreateAsync(DepartmentRequestDTO departmentRequestDto);
    Task<bool>UpdateAsync(int id, DepartmentRequestDTO departmentRequestDto);
    Task<bool>DeleteAsync(int id); 
}