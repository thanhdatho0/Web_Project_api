
using api.DTOs.PImage;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("api/images")]
    public class ImageController(IImageRepository imageRepo, IImageService imageService)
        : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetALl()
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var images = await imageRepo.GetAllAsync();

            var imagesDto = images.Select(x => x.ToImageDto());

            return Ok(imagesDto);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult?> GetById(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var image = await imageRepo.GetByIdAsync(id);

            return Ok(image?.ToImageDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create(IFormFile file, [FromForm] ImageCreateDto imageDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                // Construct base URL in the controller
                var baseUrl = $"{Request.Scheme}://{Request.Host}";

                var imageDtoResult = await imageService.CreateImageAsync(file, imageDto, baseUrl);

                return CreatedAtAction(nameof(GetById), new { id = imageDtoResult.ImageId }, imageDtoResult);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] ImageUpdateDto imageDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var image = await imageRepo.UpdateAsync(id, imageDto);

            if (image == null)
                return NotFound("Image not found");

            return Ok(image.ToImageDto());
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var image = await imageRepo.DeleteAsync(id);

            if (image == null)
                return NotFound("Image does not exists");

            return NoContent();
        }


    }
}