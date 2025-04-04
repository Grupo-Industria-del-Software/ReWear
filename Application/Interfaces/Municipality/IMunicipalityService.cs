using Application.DTOs.Municipalities;

namespace Application.Interfaces.Municipality;

public interface IMunicipalityService
{
    Task<IEnumerable<MunicipalityResponseDTO>> GetAllAsync();
    Task<MunicipalityResponseDTO?> GetByIdAsync(int id);
    Task<MunicipalityResponseDTO> CreateAsync(MunicipalityRequetsDTO dto);
    Task<bool> UpdateAsync(int id, MunicipalityRequetsDTO dto);
    Task<bool> DeleteAsync(int id);
}