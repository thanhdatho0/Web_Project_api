
using api.DTOs.ProductSize;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("api/productsizes")]
    public class ProductSizeController(
        IProductSizeRepository productSizeRepo,
        IProductRepository productRepo,
        ISizeRepository sizeRepo)
        : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetById(int productId, int sizeId)
        {
            var productSize = await productSizeRepo.GetByIdAsync(productId, sizeId);

            if (productSize == null)
                return NotFound();

            return Ok(productSize.ToProductSizeDto());
        }
        [HttpPost]
        public async Task<IActionResult> AddProductSize([FromBody] ProductSizeCreateDto productSizeDto)
        {
            var product = await productRepo.GetByIdAsync(productSizeDto.ProductId);
            var size = await sizeRepo.GetByIdAsync(productSizeDto.SizeId);

            if (product == null)
                return BadRequest("Product not found");

            if (size == null)
                return BadRequest("Size not found");

            var productSize = await productSizeRepo.GetByIdAsync(productSizeDto.ProductId, productSizeDto.SizeId);

            if (productSize != null)
                return BadRequest("Cannot add same stock to product size");

            var productSizeModel = productSizeDto.ToProductSizeFromCreateDto();

            try
            {
                await productSizeRepo.CreateAsync(productSizeModel);
            }
            catch
            {
                return StatusCode(500, "Could not create");
            }
            return Ok("Created successfully");
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int productId, int sizeId)
        {
            var productSize = await productSizeRepo.DeleteAsync(productId, sizeId);

            if (productSize == null)
                return BadRequest("Not found");
            return Ok("Successful");
        }
    }
}