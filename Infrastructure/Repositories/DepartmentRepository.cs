using Application.DTOs.DepartmentDTO;
using Application.Interfaces.Department;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class DepartmentRepository : IDepartmentRepository
{
    public readonly AlqDbContext _context;

    public DepartmentRepository(AlqDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Department>> GetAllAsync()
    {
        return await _context.Departments.ToListAsync(); 
    }

    public async Task<Department?> GetByIdAsync(int id)
    {
        return await _context.Departments.FindAsync(id);
    }

    public async Task AddAsync(Department department)
    {
        _context.Departments.Add(department);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> UpdateAsync(Department department)
    {
        _context.Update(department);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var department = await _context.Departments.FindAsync(id);
        if (department is null) return false;
        _context.Departments.Remove(department);
        return await _context.SaveChangesAsync() > 0;
    }
}