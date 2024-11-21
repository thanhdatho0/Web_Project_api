
using api.DTOs.Material;
using api.Interfaces;
using api.Mappers;
using api.Models;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MaterialController : Controller
{
    private readonly IMaterialRepository _materialRepository;
    public MaterialController(IMaterialRepository materialRepository)
    {
        _materialRepository = materialRepository;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var materials = await _materialRepository.GetAllAsync();
        return Ok(materials);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] MaterialCreateDto materialCreateDto)
    {
        var material = materialCreateDto.ToMaterialDto();
        await _materialRepository.CreateAsync(material);
        return Ok(materialCreateDto);
    }
}