
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

            return Ok(colors?.Select(c => c.ToColorDto()) ?? []);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var color = await colorRepo.GetByIdAsync(id);
            return color != null ? Ok(color.ToColorDto()) : NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ColorCreateDto colorCreateDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            
            if(await colorRepo.ColorNameExists(colorCreateDto.HexaCode, colorCreateDto.Name))
                return BadRequest("Color already exists");

            var color = colorCreateDto.ToColorFromCreateDto();
            try
            {
                await colorRepo.CreateAsync(color);
                return CreatedAtAction(nameof(GetById), new { id = color.ColorId }, color.ToColorDto());
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] ColorUpdateDto colorUpdateDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var color = await colorRepo.UpdateAsync(id, colorUpdateDto);
            return color != null ? Ok(color.ToColorDto()) : NotFound("Color does not found");
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var color = await colorRepo.DeleteAsync(id);
            return color != null ? NoContent() : NotFound("Color does not exists");
        }
    }
}