
using api.DTOs.PImage;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("api/images")]
    public class ImageController : ControllerBase
    {
        private readonly IImageRepository _imageRepo;
        private readonly IProductRepository _prodRepo;
        private readonly IColorRepository _colorRepo;

        public ImageController(IColorRepository colorRepo, IImageRepository imageRepo, IProductRepository prodRepo)
        {
            _prodRepo = prodRepo;
            _imageRepo = imageRepo;
            _colorRepo = colorRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetALl()
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var images = await _imageRepo.GetAllAsyns();

            var imagesDto = images.Select(x => x.ToImageDto());

            return Ok(imagesDto);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var image = await _imageRepo.GetByIdAsyns(id);

            if (image == null)
                return NotFound("Not found Imgage");

            return Ok(image.ToImageDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ImageCreateDto imageDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!await _colorRepo.ColorExists(imageDto.ColorId))
                return BadRequest("Color does not exist!");

            if (!await _prodRepo.ProductExists(imageDto.ProductId))
                return BadRequest("Product does not exists!");

            var imageModel = imageDto.ToImageFromCreateDto();

            if (imageModel == null)
                return BadRequest("Not create");

            await _imageRepo.CreateAsyns(imageModel);

            return CreatedAtAction(nameof(GetById), new { id = imageModel.ImageId }, imageModel.ToImageDto());
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] ImageUpdateDto imageDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var image = await _imageRepo.UpdateAsyns(id, imageDto);

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

            var image = await _imageRepo.DeleteAsync(id);

            if (image == null)
                return NotFound("Image does not exists");

            return NoContent();
        }


    }
}