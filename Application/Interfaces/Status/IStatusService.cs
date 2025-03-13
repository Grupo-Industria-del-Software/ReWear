using Application.DTOs.Status;
using Domain.Common;

namespace Application.Interfaces.Status
{
    public interface IStatusService<T, TStatusRequestDTO, TStatusResponseDTO>
        where T: EntityStatusCatalog
        where TStatusRequestDTO: StatusRequestDTO
        where TStatusResponseDTO: StatusResponseDTO
    {
        Task<IEnumerable<TStatusResponseDTO>> GetAllAsync();
        Task<TStatusResponseDTO?> GetByIdAsync(int id);
        Task<TStatusResponseDTO> CreateAsync(TStatusRequestDTO statusRequestDto);
        Task<bool> UpdateAsync(int id, TStatusRequestDTO statusRequestDto);
        Task<bool> DeleteAsync(int id);
    }
}
