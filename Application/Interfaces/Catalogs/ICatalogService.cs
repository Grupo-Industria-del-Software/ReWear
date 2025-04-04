using Application.DTOs.Catalogs;
using Domain.Common;

namespace Application.Interfaces.Catalogs
{
    public interface ICatalogService<T, TStatusRequestDTO, TStatusResponseDTO>
        where T : EntityCatalog
        where TStatusRequestDTO : CatalogRequestDto
        where TStatusResponseDTO : CatalogResponseDto
    {
        Task<IEnumerable<TStatusResponseDTO>> GetAllAsync();
        Task<TStatusResponseDTO?> GetByIdAsync(int id);
        Task<TStatusResponseDTO> CreateAsync(TStatusRequestDTO statusRequestDto);
        Task<bool> UpdateAsync(int id, TStatusRequestDTO statusRequestDto);
        Task<bool> DeleteAsync(int id);
    }
}
