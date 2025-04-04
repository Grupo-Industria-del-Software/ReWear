using Application.DTOs.Municipalities;
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

        public async Task<IEnumerable<MunicipalityResponseDto>> GetAllAsync()
        {
            var municipalities = await _repository.GetAllAsync();
            return municipalities.Select(m => new MunicipalityResponseDto
            {
                Id = m.Id,
                Name = m.Name,
                DepartmentId = m.DepartmentId
            });
        }

        public async Task<MunicipalityResponseDto?> GetByIdAsync(int id)
        {
            var municipality = await _repository.GetByIdAsync(id);
            return municipality is null ? null : new MunicipalityResponseDto
            {
                Id = municipality.Id,
                Name = municipality.Name,
                DepartmentId = municipality.DepartmentId
            };
        }

        public async Task<MunicipalityResponseDto> CreateAsync(MunicipalityRequetsDto dto)
        {
            var municipality = new Municipality()
            {
                Name = dto.Name,
                DepartmentId = dto.DepartmentId
            };
            await _repository.AddAsync(municipality);
            return new MunicipalityResponseDto
            {
                Id = municipality.Id,
                Name = municipality.Name,
                DepartmentId = municipality.DepartmentId
            };
        }

        public async Task<bool> UpdateAsync(int id, MunicipalityRequetsDto dto)
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
