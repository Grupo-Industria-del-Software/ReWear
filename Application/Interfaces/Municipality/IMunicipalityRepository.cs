namespace Application.Interfaces.Municipality;

public interface IMunicipalityRepository
{
    Task<IEnumerable<Domain.Entities.Municipality>> GetAllAsync();
    Task<Domain.Entities.Municipality?> GetByIdAsync(int id);
    Task AddAsync(Domain.Entities.Municipality municipality);
    Task<bool> UpdateAsync(Domain.Entities.Municipality municipality);
    Task<bool> DeleteAsync(int id);
}