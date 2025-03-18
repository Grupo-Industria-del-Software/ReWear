namespace Application.Interfaces.Department;

public interface IDepartmentRepository
{
    Task<IEnumerable<Domain.Entities.Department>>GetAllAsync();
    Task<Domain.Entities.Department?> GetByIdAsync(int id);
    Task AddAsync(Domain.Entities.Department department);
    Task <bool>UpdateAsync(Domain.Entities.Department department);
    Task<bool>DeleteAsync(int id);

}