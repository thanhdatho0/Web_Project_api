using api.DTOs.Department;
using api.Models;
using Microsoft.AspNetCore.Mvc;

namespace api.Interfaces;

public interface IDepartmentRepository
{
    public Task<List<Department>> GetAllAsync();
    public Task<Department?> GetByIdAsync(int id);
    public Task<Department?> CreateAsync(Department department);
    public Task<Department?> UpdateAsync(int id, DepartmentUpdateDto departmentUpdateDto);
    Task<bool> DepartmentExists(int id);

}