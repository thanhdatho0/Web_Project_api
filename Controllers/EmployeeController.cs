using api.DTOs.Employee;
using api.Interfaces;
using api.Mappers;
using api.Models;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EmployeeController : ControllerBase
{
    private readonly IEmployeeRepository _employeeRepository;
    private readonly IDepartmentRepository _departmentRepo;

    public EmployeeController(IEmployeeRepository employeeRepository, IDepartmentRepository departmentRepo)
    {
        _employeeRepository = employeeRepository;
        _departmentRepo = departmentRepo;
    }
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        var employees = await _employeeRepository.GetAllAsync();
        return Ok(employees.Select(x => x.ToEmployeeDto()));
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        var employee = await _employeeRepository.GetByIdAsync(id);
        if (employee == null) return NotFound();
        return Ok(employee.ToEmployeeDto());
    }

    [HttpPost]
    public async Task<IActionResult> Create(EmployeeCreateDto employeeCreateDto)
    {

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        if (!await _departmentRepo.DepartmentExists(employeeCreateDto.DepartmentId))
            return BadRequest("Department does not exist!");

        var employee = employeeCreateDto.ToCreateEmployeeDto();
        try
        {
            await _employeeRepository.CreateAsync(employee);
            return Ok(employee.ToEmployeeDto());
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }
}