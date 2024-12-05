
using System.Diagnostics;
using api.DTOs.Size;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/sizes")]
    [ApiController]

    public class SizeController(ISizeRepository sizeRepo) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var sizes = await sizeRepo.GetAllAsync();
            return Ok(sizes);
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var size = await sizeRepo.GetByIdAsync(id);

            if (size == null)
                return NotFound();

            return Ok(size.ToSizeDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] SizeCreateDto sizeCreateDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            
            if(await sizeRepo.SizeNameExists(sizeCreateDto.SizeValue))
                return BadRequest("Size already exists");

            var size = sizeCreateDto.ToSizeFromCreateDto();

            await sizeRepo.CreateAsync(size);

            return CreatedAtAction(nameof(GetById), new { id = size.SizeId }, size.ToSizeDto());
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] SizeUpdateDto sizeDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var size = await sizeRepo.UpdateAsync(id, sizeDto);

            if (size == null)
                return NotFound("Product not found");

            return Ok(size.ToSizeDto());
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var size = await sizeRepo.DeleteAsync(id);

            if (size == null)
                return NotFound("Product does not exists");

            return NoContent();
        }
    }
}