
using api.DTOs.ProductColor;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductColorController(
        IProductColorRepository productColorRepo,
        IProductRepository productRepo,
        IColorRepository colorRepo)
        : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetById(int productId, int colorId)
        {
            var productColor = await productColorRepo.GetByIdAsync(productId, colorId);

            if (productColor == null)
                return NotFound();

            return Ok(productColor.ToProductColorDto());
        }

        [HttpPost]
        public async Task<IActionResult> AddProductColor([FromBody] ProductColorCreateDto productColorDto)
        {
            var product = await productRepo.GetByIdAsync(productColorDto.ProductId);
            var color = await colorRepo.GetByIdAsync(productColorDto.ColorId);

            if (product == null)
                return BadRequest("Product not found");

            if (color == null)
                return BadRequest("Color not found");

            var productColor = await productColorRepo.GetByIdAsync(productColorDto.ProductId, productColorDto.ColorId);

            if (productColor != null)
                return BadRequest("Cannot add same stock to product color");

            var productColorModel = productColorDto.ToProductColorFromCreateDto();

            try
            {
                await productColorRepo.CreateAsync(productColorModel);
            }
            catch (Exception e)
            {
                return StatusCode(500, "Error has occured: " + e.Message);
            }
            return Ok("Created successfully");
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int productId, int colorId)
        {
            var productColor = await productColorRepo.DeleteAsync(productId, colorId);

            if (productColor == null)
                return BadRequest("Not found");
            return Ok("Successful");
        }
    }
}