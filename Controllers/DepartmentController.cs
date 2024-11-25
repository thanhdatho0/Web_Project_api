using api.DTOs.Department;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;

[Route("api/[controller]")]  
[ApiController]
public class DepartmentController : ControllerBase
{
    private readonly IDepartmentRepository _departmentRepository;

    public DepartmentController(IDepartmentRepository departmentRepository)
    {
        _departmentRepository = departmentRepository;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        if(!ModelState.IsValid) return BadRequest(ModelState);
        var departments = await _departmentRepository.GetAllAsync();
        return Ok(departments.Select(x => x.ToDepartmentDto()));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        if(!ModelState.IsValid) return BadRequest(ModelState);
        var department = await _departmentRepository.GetByIdAsync(id);
        return department == null ? NotFound() : Ok(department.ToDepartmentDto());
    }

    [HttpPost]
    public async Task<IActionResult> Create(DepartmentCreateDto departmentCreateDto)
    {
        try
        {
            await _departmentRepository.CreateAsync(departmentCreateDto.ToCreateDepartmentDto());
            return Ok(departmentCreateDto);
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, DepartmentUpdateDto departmentUpdateDto)
    {
        if(!ModelState.IsValid) return BadRequest(ModelState);
        var department = await _departmentRepository.UpdateAsync(id, departmentUpdateDto);
        return department == null ? NotFound() : Ok(department.ToDepartmentDto());
    }
}