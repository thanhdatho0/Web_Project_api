using api.DTOs.Employee;
using api.Models;

namespace api.Interfaces;

public interface IEmployeeRepository
{
    Task<List<Employee>> GetAllAsync();
    Task<Employee?> GetByIdAsync(int id);
    Task<Employee?> CreateAsync(Employee employee);
    //Task<Employee?> UpdateAsync(int id, EmployeeUpdateDto employeeUpdateDto);
    // Task<Employee?> DeleteAsync(int id);
}