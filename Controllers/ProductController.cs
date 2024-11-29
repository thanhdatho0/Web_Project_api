
using api.DTOs.Product;
using api.Interfaces;
using api.Mappers;
using api.Models;
using Microsoft.AspNetCore.Mvc;
using api.Helpers;


namespace api.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductController(
        IProductRepository productRepo,
        IProviderRepository providerRepo,
        IProductSizeRepository productSizeRepo,
        IProductMaterialRepository productMaterialRepo,
        IImageRepository imageRepo,
        IProductColorRepository productColorRepo,
        ISubcategoryRepository subcategoryRepo)
        : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] ProductQuery query)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var products = await productRepo.GetAllAsync(query);

            var productsDto = products.Select(x => x.ToProductDto());

            return Ok(productsDto);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var product = await productRepo.GetByIdAsync(id);

            if (product == null)
                return NotFound();

            return Ok(product.ToProductDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ProductCreateDto productDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!await subcategoryRepo.SubcategoryExists(productDto.SubcategoryId))
                return BadRequest("Subcategory does not exist!");

            if (!await providerRepo.ProviderExists(productDto.ProviderId))
                return BadRequest("Provider does not exists!");

            var productModel = productDto.ToProductFromCreateDto();

            await productRepo.CreateAsync(productModel);
            foreach (var size in productDto.SizeId!)
            {
                var productSize = new ProductSize { ProductId = productModel.ProductId, SizeId = size };
                await productSizeRepo.CreateAsync(productSize);
            }

            foreach (var material in productDto.MaterialId!)
            {
                var productMaterial = new ProductMaterial { ProductId = productModel.ProductId, MaterialId = material };
                await productMaterialRepo.CreateAsync(productMaterial);
            }

            foreach (var color in productDto.Colors!)
            {
                foreach (var image in color.Images!)
                {
                    var imageModel = image.ToImageFromCreateProductDto();
                    imageModel.ProductId = productModel.ProductId;
                    await imageRepo.CreateAsync(imageModel);
                }
                var colorProduct = new ProductColor { ProductId = productModel.ProductId, ColorId = color.ColorId };
                await productColorRepo.CreateAsync(colorProduct);
            }

            return Ok(productDto);
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] ProductUpdateDto productDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var product = await productRepo.UpdateAsync(id, productDto);

            if (product == null)
                return NotFound("Product not found");

            return Ok(product.ToProductDto());
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var product = await productRepo.DeleteAsync(id);

            if (product == null)
                return NotFound("Product does not exists");

            return NoContent();
        }
    }
}