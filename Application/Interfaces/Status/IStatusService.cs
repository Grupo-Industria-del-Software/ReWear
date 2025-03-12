using Application.DTOs.Status;
using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Status
{
    public interface IStatusService<T, TStatusRequestDTO, TStatusResponseDTO>
        where T: EntityStatusCatalog
        where TStatusRequestDTO: StatusRequestDTO
        where TStatusResponseDTO: StatusResponseDTO
    {
        Task<IEnumerable<TStatusResponseDTO>> GetAllAsync();
        Task<TStatusResponseDTO?> GetByIdAsync(int id);
        Task<TStatusResponseDTO> CreateAsync(TStatusRequestDTO statusRequestDTO);
        Task<bool> UpdateAsync(int id, TStatusRequestDTO statusRequestDTO);
        Task<bool> DeleteAsync(int id);
    }
}
