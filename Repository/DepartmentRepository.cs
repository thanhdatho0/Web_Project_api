using api.Data;
using api.DTOs.Department;
using api.Interfaces;
using api.Mappers;
using api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Repository;

public class DepartmentRepository : IDepartmentRepository
{
    private readonly ApplicationDbContext _context;

    public DepartmentRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Department>> GetAllAsync()
    {
        return await _context.Departments.ToListAsync();
    }

    public async Task<Department?> GetByIdAsync(int id)
    {
        var department = await _context.Departments.FindAsync(id);
        return department ?? null;
    }

    public async Task<Department?> CreateAsync(Department department)
    {
        await _context.Departments.AddAsync(department);
        await _context.SaveChangesAsync();
        return department;
    }

    public async Task<Department?> UpdateAsync(int id, DepartmentUpdateDto departmentUpdateDto)
    {
        var department = await _context.Departments.FindAsync(id);
        if (department == null) return null;
        _context.Entry(department).CurrentValues.SetValues(departmentUpdateDto);
        await _context.SaveChangesAsync();
        return department;
    }

    public Task<bool> DepartmentExists(int id)
    {
        return _context.Departments.AnyAsync(d => d.DepartmentId == id);
    }
}