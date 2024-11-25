using api.Data;
using api.DTOs.Employee;
using api.Interfaces;
using api.Mappers;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository;

public class EmployeeRepository : IEmployeeRepository
{
    private readonly ApplicationDbContext _context;

    public EmployeeRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Employee>> GetAllAsync()
    {
        return await _context.Employees.Include(e => e.Department).ToListAsync();
    }

    public async Task<Employee?> GetByIdAsync(int id)
    {
        return await _context.Employees
            .Include(e => e.Department)
            .FirstOrDefaultAsync(e => e.EmployeeId == id);
    }

    public async Task<Employee?> CreateAsync(Employee employee)
    {
        await _context.Employees.AddAsync(employee);
        await _context.SaveChangesAsync();
        return employee;
    }

    public async Task<Employee?> UpdateAsync(int id, EmployeeUpdateDto employeeUpdateDto)
    {
        var employee = _context.Employees.FirstOrDefault(e => e.EmployeeId == id);
        if (employee == null) return null;
        employee = employeeUpdateDto.ToEmployeeUpdate();
        await _context.SaveChangesAsync();
        return employee;
    }

    public async Task<Employee?> DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }
}