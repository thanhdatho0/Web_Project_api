using api.Data;
using api.DTOs.Employee;
using api.Interfaces;
using api.Mappers;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository;

public class EmployeeRepository(ApplicationDbContext context) : IEmployeeRepository
{
    public async Task<List<Employee>> GetAllAsync()
    {
        return await context.Employees.ToListAsync();
    }

    public async Task<Employee?> GetByIdAsync(int id)
    {
        return await context.Employees.FindAsync(id);
    }

    public async Task<Employee?> CreateAsync(Employee employee)
    {
        await context.Employees.AddAsync(employee);
        await context.SaveChangesAsync();
        return employee;
    }

    public async Task<Employee?> UpdateAsync(int id, EmployeeUpdateDto employeeUpdateDto)
    {
        var employee = context.Employees.FirstOrDefault(e => e.EmployeeId == id);
        if (employee == null) return null;
        employee = employeeUpdateDto.ToEmployeeUpdate();
        await context.SaveChangesAsync();
        return employee;
    }

    public async Task<Employee?> DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }
}