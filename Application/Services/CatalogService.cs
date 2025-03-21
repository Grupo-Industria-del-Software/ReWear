﻿using Application.DTOs.Catalogs;
using Application.Interfaces.Catalogs;
using Domain.Common;

namespace Application.Services
{
    public class CatalogService<T, TCatalogRequestDTO, TCatalogResponseDTO> : ICatalogService<T, TCatalogRequestDTO, TCatalogResponseDTO>
        where T : EntityCatalog, new()
        where TCatalogRequestDTO : CatalogRequestDTO
        where TCatalogResponseDTO : CatalogResponseDTO, new()
    {
        private readonly ICatalogRepository<T> _repository;

        public CatalogService(ICatalogRepository<T> repository)
        {
            _repository = repository;
        }


        public async Task<TCatalogResponseDTO> CreateAsync(TCatalogRequestDTO catalogRequestDTO)
        {
            var catalog = new T { Label = catalogRequestDTO.Label };
            await _repository.AddAsync(catalog);
            return new TCatalogResponseDTO
            {
                Id = catalog.Id,
                Label = catalog.Label,
            };
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<TCatalogResponseDTO>> GetAllAsync()
        {
            var catalogs = await _repository.GetAllAsync();
            return catalogs.Select(x => new TCatalogResponseDTO
            {
                Id = x.Id,
                Label = x.Label
            });
        }

        public async Task<TCatalogResponseDTO?> GetByIdAsync(int id)
        {
        
            var catalog = await _repository.GetByIdAsync(id);

            return catalog is null ? null : new TCatalogResponseDTO
            {
                Id = catalog.Id,
                Label = catalog.Label,
            };
        }

        public async Task<bool> UpdateAsync(int id, TCatalogRequestDTO catalogRequestDTO)
        {
            var catalog = await _repository.GetByIdAsync(id);
            if (catalog is null) return false;

            catalog.Label = catalogRequestDTO.Label;

            return await _repository.UpdateAsync(catalog);

        }
    }
}
