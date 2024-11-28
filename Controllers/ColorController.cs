
using api.Interfaces;
using api.Mappers;
using api.DTOs.PColor;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/colors")]
    [ApiController]

    public class ColorController(IColorRepository colorRepo) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var colors = await colorRepo.GetAllAsync();

            var colorsDto = colors.Select(c => c.ToColorDto());

            return Ok(colorsDto);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var color = await colorRepo.GetByIdAsync(id);

            if (color == null)
                return NotFound();

            return Ok(color.ToColorDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ColorCreateDto colorCreateDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var color = colorCreateDto.ToColorFromCreateDto();

            await colorRepo.CreateAsync(color);

            return CreatedAtAction(nameof(GetById), new { id = color.ColorId }, color.ToColorDto());
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] ColorUpdateDto colorUpdateDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var color = await colorRepo.UpdateAsync(id, colorUpdateDto);

            if (color == null)
                return NotFound("Color does not found");

            return Ok(color.ToColorDto());
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var color = await colorRepo.DeleteAsync(id);

            if (color == null)
                return NotFound("Color does not exists");

            return NoContent();
        }


    }
}