using Application.DTOs.ConditionsDTO;
using Application.DTOs.ConditionsDTOs;
using Application.Interfaces.Conditions;
using Domain.Entities;

namespace Application.Services.Conditions
{
    public class ConditionService : IConditionService
    {
        private readonly IConditionRepository _conditionRepository;

        public ConditionService(IConditionRepository conditionRepository)
        {
            _conditionRepository = conditionRepository;
        }

        public async Task<IEnumerable<ConditionResponseDTO>> GetAllAsync()
        {
            var conditions = await _conditionRepository.GetAllAsync();
            return conditions.Select(c => new ConditionResponseDTO
            {
                Id = c.Id,
                Name = c.Name
            });
        }

        public async Task<ConditionResponseDTO?> GetByIdAsync(int id)
        {
            var condition = await _conditionRepository.GetByIdAsync(id);
            if (condition == null)
                return null;

            return new ConditionResponseDTO
            {
                Id = condition.Id,
                Name = condition.Name
            };
        }

        public async Task<ConditionResponseDTO> CreateAsync(ConditionRequestDTO dto)
        {
            var condition = new Condition
            {
                Name = dto.Name
            };

            await _conditionRepository.AddAsync(condition);

            return new ConditionResponseDTO
            {
                Id = condition.Id,
                Name = condition.Name
            };
        }

        public async Task<bool> UpdateAsync(int id, ConditionRequestDTO dto)
        {
            var condition = await _conditionRepository.GetByIdAsync(id);
            if (condition == null)
                return false;

            condition.Name = dto.Name;

            return await _conditionRepository.UpdateAsync(condition);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _conditionRepository.DeleteAsync(id);
        }
    }
}
