
using api.DTOs.Material;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MaterialController(IMaterialRepository materialRepository) : Controller
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var materials = await materialRepository.GetAllAsync();
        return Ok(materials);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] MaterialCreateDto materialCreateDto)
    {
        var material = materialCreateDto.ToMaterialDto();
        await materialRepository.CreateAsync(material);
        return Ok(materialCreateDto);
    }
}