using api.Data;
using api.DTOs.Product;
using api.DTOs.ProductSize;
using api.DTOs.Size;
using api.Interfaces;
using api.Mappers;
using api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using api.Helpers;
using Microsoft.AspNetCore.Http.HttpResults;


namespace api.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepo;
        private readonly ISubcategoryRepository _subcategoryRepo;
        private readonly IProviderRepository _providerRepo;
        private readonly IProductSizeRepository _productSizeRepo;
        private readonly IProductMaterialRepository _productMaterialRepo;

        public ProductController(IProductRepository productRepo, ICategoryRepository categoryRepo, 
            IProviderRepository providerRepo, IProductSizeRepository productSizeRepo, IProductMaterialRepository productMaterialRepo)
        {
            _productRepo = productRepo;
            _subcategoryRepo = subcategoryRepo;
            _providerRepo = providerRepo;
            _productSizeRepo = productSizeRepo;
            _productMaterialRepo = productMaterialRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] ProductQuery query)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var products = await _productRepo.GetAllAsync(query);

            var productsDto = products.Select(x => x.ToProductDto());

            return Ok(productsDto);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var product = await _productRepo.GetByIdAsync(id);

            if (product == null)
                return NotFound();

            return Ok(product.ToProductDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ProductCreateDto productDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!await _subcategoryRepo.SubcategoryExists(productDto.SubcategoryId))
                return BadRequest("Subcategory does not exist!");

            if (!await _providerRepo.ProviderExists(productDto.ProviderId))
                return BadRequest("Provider does not exists!");

            var productModel = productDto.ToProductFromCreateDto();

            if (productModel == null)
                return BadRequest("Not create");

            await _productRepo.CreateAsync(productModel);
            foreach (var size in productDto.SizeId!)
            {
                var productSize = new ProductSize { ProductId = productModel.ProductId, SizeId = size };
                await _productSizeRepo.CreateAsync(productSize);
            }

            foreach (var material in productDto.MaterialId!)
            {
                var productMaterial = new ProductMaterial { ProductId = productModel.ProductId, MaterialId = material };
                await _productMaterialRepo.CreateAsync(productMaterial);
            }

            return Ok(productDto);
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] ProductUpdateDto productDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var product = await _productRepo.UpdateAsync(id, productDto);

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

            var product = await _productRepo.DeleteAsync(id);

            if (product == null)
                return NotFound("Product does not exists");

            return NoContent();
        }

    }
}