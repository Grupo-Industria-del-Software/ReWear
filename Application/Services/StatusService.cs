using Application.DTOs.Status;
using Application.Interfaces.Status;
using Domain.Common;

namespace Application.Services
{
    public class StatusService<T, TStatusRequestDTO, TStatusResponseDTO> : IStatusService<T, TStatusRequestDTO, TStatusResponseDTO>
        where T : EntityStatusCatalog, new()
        where TStatusRequestDTO : StatusRequestDTO
        where TStatusResponseDTO : StatusResponseDTO, new()
    {
        private readonly IStatusRepository<T> _repository;

        public StatusService(IStatusRepository<T> repository)
        {
            _repository = repository;
        }


        public async Task<TStatusResponseDTO> CreateAsync(TStatusRequestDTO statusRequestDTO)
        {
            var status = new T { Status = statusRequestDTO.Status };
            await _repository.AddAsync(status);
            return new TStatusResponseDTO
            {
                Id = status.Id,
                Status = status.Status,
            };
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<TStatusResponseDTO>> GetAllAsync()
        {
            var status = await _repository.GetAllAsync();
            return status.Select(x => new TStatusResponseDTO
            {
                Id = x.Id,
                Status = x.Status
            });
        }

        public async Task<TStatusResponseDTO?> GetByIdAsync(int id)
        {
        
            var status = await _repository.GetByIdAsync(id);

            return status is null ? null : new TStatusResponseDTO
            {
                Id = status.Id,
                Status = status.Status,
            };
        }

        public async Task<bool> UpdateAsync(int id, TStatusRequestDTO statusRequestDTO)
        {
            var status = await _repository.GetByIdAsync(id);
            if (status is null) return false;
            
            status.Status = statusRequestDTO.Status;

            return await _repository.UpdateAsync(status);

        }
    }
}
