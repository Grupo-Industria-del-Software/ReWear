﻿using Application.Interfaces.Catalogs;
using Domain.Common;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class CatalogRepository<T> : ICatalogRepository<T>
        where T : EntityCatalog
    {

        private readonly AlqDbContext _dbContext;
        private readonly DbSet<T> _dbSet;

        public CatalogRepository(AlqDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<T>();
        }

        public async Task AddAsync(T entity)
        {
            _dbSet.Add(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var catalog = await _dbSet.FindAsync(id);
            if(catalog == null)
            {
                return false;
            }

            _dbSet.Remove(catalog);
            return await _dbContext.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<bool> UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
            return await _dbContext.SaveChangesAsync() > 0;
        }
    }
}
