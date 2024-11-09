using api.Data;
using api.Interfaces;
using api.Mappers;
using api.DTOs.PColor;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/colors")]
    [ApiController]

    public class ColorController : ControllerBase
    {
        private readonly IColorRepository _colorRepo;

        public ColorController(IColorRepository colorRepo)
        {
            _colorRepo = colorRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var colors = await _colorRepo.GetAllAsync();
            var colorsDto = colors.Select(c => c.ToColorDto());
            return Ok(colorsDto);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var color = await _colorRepo.GetByIdAsync(id);
            if (color == null) return NotFound();
            return Ok(color.ToColorDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ColorCreateDto colorCreateDto)
        {
            var color = colorCreateDto.ToColorFromCreateDto();
            await _colorRepo.CreateAsync(color);
            return CreatedAtAction(nameof(GetById), new { id = color.ColorId }, color.ToColorDto());
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] ColorUpdateDto colorUpdateDto)
        {
            var color = await _colorRepo.UpdateAsync(id, colorUpdateDto);
            if (color == null)
                return NotFound("Color does not found");
            return Ok(color.ToColorDto());
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var color = await _colorRepo.DeleteAsync(id);
            if (color == null)
                return NotFound("Color does not exists");
            return NoContent();
        }


    }
}