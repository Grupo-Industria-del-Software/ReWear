using Application.DTOs.Municipalities;

namespace Application.Interfaces.Municipality;

public interface IMunicipalityService
{
    Task<IEnumerable<MunicipalityResponseDto>> GetAllAsync();
    Task<MunicipalityResponseDto?> GetByIdAsync(int id);
    Task<MunicipalityResponseDto> CreateAsync(MunicipalityRequetsDto dto);
    Task<bool> UpdateAsync(int id, MunicipalityRequetsDto dto);
    Task<bool> DeleteAsync(int id);
}