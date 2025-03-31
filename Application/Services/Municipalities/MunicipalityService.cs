using Application.DTOs.MunicipalityDTO;
using Application.Interfaces.Municipality;
using Domain.Entities;

namespace Application.Services.Municipalities;

public class MunicipalityService:IMunicipalityService
{
   private readonly IMunicipalityRepository _repository;

        public MunicipalityService(IMunicipalityRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<MunicipalityResponseDTO>> GetAllAsync()
        {
            var municipalities = await _repository.GetAllAsync();
            return municipalities.Select(m => new MunicipalityResponseDTO
            {
                Id = m.Id,
                Name = m.Name,
                DepartmentId = m.DepartmentId
            });
        }

        public async Task<MunicipalityResponseDTO?> GetByIdAsync(int id)
        {
            var municipality = await _repository.GetByIdAsync(id);
            return municipality is null ? null : new MunicipalityResponseDTO
            {
                Id = municipality.Id,
                Name = municipality.Name,
                DepartmentId = municipality.DepartmentId
            };
        }

        public async Task<MunicipalityResponseDTO> CreateAsync(MunicipalityRequetsDTO dto)
        {
            var municipality = new Municipality()
            {
                Name = dto.Name,
                DepartmentId = dto.DepartmentId
            };
            await _repository.AddAsync(municipality);
            return new MunicipalityResponseDTO
            {
                Id = municipality.Id,
                Name = municipality.Name,
                DepartmentId = municipality.DepartmentId
            };
        }

        public async Task<bool> UpdateAsync(int id, MunicipalityRequetsDTO dto)
        {
            var municipality = await _repository.GetByIdAsync(id);
            if (municipality is null) return false;

            municipality.Name = dto.Name;
            municipality.DepartmentId = dto.DepartmentId;

            return await _repository.UpdateAsync(municipality);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }
    }
