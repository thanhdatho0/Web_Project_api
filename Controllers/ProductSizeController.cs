
using api.DTOs.ProductSize;
using api.Interfaces;
using api.Mappers;
using api.Models;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("api/productsizes")]
    public class ProductSizeController : ControllerBase
    {
        private readonly IProductRepository _productRepo;
        private readonly ISizeRepository _sizeRepo;
        private readonly IProductSizeRepository _productSizeRepo;
        public ProductSizeController(IProductSizeRepository productSizeRepo, IProductRepository productRepo
        , ISizeRepository sizeRepo)
        {
            _productSizeRepo = productSizeRepo;
            _sizeRepo = sizeRepo;
            _productRepo = productRepo;
        }
        [HttpGet]
        public async Task<IActionResult> GetById(int productId, int sizeId)
        {
            var productsize = await _productSizeRepo.GetByIdAsync(productId, sizeId);

            if (productsize == null)
                return NotFound();

            return Ok(productsize.ToProductSizeDto());
        }
        [HttpPost]
        public async Task<IActionResult> AddProductSize([FromBody] ProductSizeCreateDto productSizeDto)
        {
            var produdct = await _productRepo.GetByIdAsync(productSizeDto.ProductId);
            var size = await _sizeRepo.GetByIdAsync(productSizeDto.SizeId);

            if (produdct == null)
                return BadRequest("Product not found");

            if (size == null)
                return BadRequest("Size not found");

            var productSize = await _productSizeRepo.GetByIdAsync(productSizeDto.ProductId, productSizeDto.SizeId);

            if (productSize != null)
                return BadRequest("Cannot add same stock to productsize");

            var productSizeModel = productSizeDto.ToProductSizeFromCreateDto();

            await _productSizeRepo.CreateAsync(productSizeModel);

            if (productSizeModel == null)
                return StatusCode(500, "Could not create");

            else
                return Ok("Created successfully");
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int productId, int sizeId)
        {
            var productSize = await _productSizeRepo.DeleteAsync(productId, sizeId);

            if (productSize == null)
                return BadRequest("Not found");
            return Ok("Successful");
        }
    }
}