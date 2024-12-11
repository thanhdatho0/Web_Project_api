using api.DTOs.Employee;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EmployeeController(IEmployeeRepository employeeRepository) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        var employees = await employeeRepository.GetAllAsync();
        return Ok(employees.Select(x => x.ToEmployeeDto()));
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        var employee = await employeeRepository.GetByIdAsync(id);
        if (employee == null) return NotFound();
        return Ok(employee.ToEmployeeDto());
    }
}