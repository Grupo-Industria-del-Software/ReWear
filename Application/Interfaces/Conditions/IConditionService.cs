using Application.DTOs.ConditionsDTO;
using Application.DTOs.ConditionsDTOs;

namespace Application.Interfaces.Conditions
{
    public interface IConditionService
    {
        Task<IEnumerable<ConditionResponseDTO>> GetAllAsync();
        Task<ConditionResponseDTO?> GetByIdAsync(int id);
        Task<ConditionResponseDTO> CreateAsync(ConditionRequestDTO dto);
        Task<bool> UpdateAsync(int id, ConditionRequestDTO dto);
        Task<bool> DeleteAsync(int id);
    }
}

