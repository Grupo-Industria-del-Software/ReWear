using Application.DTOs.Departments;
using Application.Interfaces.Department;

namespace Application.Services.Departments;

public class DepartmentService : IDepartmentService
{
    private readonly IDepartmentRepository _repository;

    public DepartmentService(IDepartmentRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<DepartmentResponseDto>> GetAllAsync()
    {
        var department = await _repository.GetAllAsync();
        return department.Select(d => new DepartmentResponseDto
        {
            Id = d.Id, DepartmentName = d.DepartmentName
        });
    }

    public async Task<DepartmentResponseDto?> GetByIdAsync(int id)
    {
        var department = await _repository.GetByIdAsync(id);
        return department is null
            ? null
            : new DepartmentResponseDto
            {
                Id = department.Id, DepartmentName = department.DepartmentName
            };
    }

    public async Task<DepartmentResponseDto> CreateAsync(DepartmentRequestDto departmentRequestDto)
    {
        var department = new Domain.Entities.Department(departmentRequestDto.DepartmentName);
        await _repository.AddAsync(department);
        return new DepartmentResponseDto
        {
            Id = department.Id, DepartmentName = department.DepartmentName
        };
    }

    public async Task<bool> UpdateAsync(int id, DepartmentRequestDto departmentRequestDto)
    {
        var department = await _repository.GetByIdAsync(id);
        if (department is null) return false;
        department.DepartmentName = departmentRequestDto.DepartmentName;
        return await _repository.UpdateAsync(department);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        return await _repository.DeleteAsync(id);
    }
}
