
using api.DTOs.Product;
using api.Interfaces;
using api.Mappers;
using api.Models;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("api/productcolors")]
    public class ProductColorController : ControllerBase
    {
        private readonly IProductRepository _productRepo;
        private readonly IColorRepository _colorRepo;
        private readonly IProductColorRepository _productColorRepo;

        public ProductColorController(IProductColorRepository productColorRepo, IProductRepository productRepo
        , IColorRepository colorRepo)
        {
            _productColorRepo = productColorRepo;
            _colorRepo = colorRepo;
            _productRepo = productRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetById(int productId, int colorId)
        {
            var productcolor = await _productColorRepo.GetByIdAsync(productId, colorId);

            if (productcolor == null)
                return NotFound();

            return Ok(productcolor.ToProductColorDto());
        }

        [HttpPost]
        public async Task<IActionResult> AddProductColor(int productId, int colorId)
        {
            var produdct = await _productRepo.GetByIdAsync(productId);
            var color = await _colorRepo.GetByIdAsync(colorId);

            if (produdct == null)
                return BadRequest("Product not found");

            if (color == null)
                return BadRequest("Color not found");

            var productColor = await _productColorRepo.GetByIdAsync(productId, colorId);

            if (productColor != null)
                return BadRequest("Cannot add same stock to productcolor");

            var productColorModel = new ProductColor
            {
                ColorId = colorId,
                ProductId = productId
            };

            await _productColorRepo.CreateAsync(productColorModel);

            if (productColorModel == null)
                return StatusCode(500, "Could not create");

            else
                return Ok("Created successfully");
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int productId, int colorId)
        {
            var productColor = await _productColorRepo.DeleteAsync(productId, colorId);

            if (productColor == null)
                return BadRequest("Not found");
            return Ok("Successful");
        }
    }
}