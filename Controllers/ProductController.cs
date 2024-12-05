
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
        IImageRepository imageRepo,
        IInventoryRepository inventoryRepo,
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

            var isSubCategoryExists = subcategoryRepo.SubcategoryExists(productDto.SubcategoryId);
            var isProviderExists = providerRepo.ProviderExists(productDto.ProviderId);
            var isProductExists = productRepo.ProductNameExists(productDto.Name);
            
            await Task.WhenAll(isSubCategoryExists, isProviderExists, isProductExists);
            
            if (!isSubCategoryExists.Result)
                return BadRequest("Subcategory does not exist!");

            if (!isProviderExists.Result)
                return BadRequest("Provider does not exists!");
            
            if(isProductExists.Result)
               return BadRequest("Product already exists!"); 

            var productModel = productDto.ToProductFromCreateDto();
            productModel.Quantity = productDto.Inventory.Select(p => p.Quantity).Sum();
            productModel.InStock = productModel.Quantity;
            
            await productRepo.CreateAsync(productModel);
            foreach (var inventoryCreateDto in productDto.Inventory)
            {
                var inventory = new Inventory
                {
                    ProductId = productModel.ProductId, 
                    SizeId = inventoryCreateDto.SizeId, 
                    ColorId = inventoryCreateDto.Color.ColorId, 
                    Quantity = inventoryCreateDto.Quantity,
                    InStock = inventoryCreateDto.Quantity,
                };
                await inventoryRepo.CreateAsync(inventory);
            }

            foreach (var color in productDto.Inventory.Select(x => x.Color).Distinct())
            {
                foreach (var image in color.Images!)
                {
                    var imageModel = image.ToImageFromCreateProductDto();
                    imageModel.ColorId = color.ColorId;
                    imageModel.ProductId = productModel.ProductId;
                    await imageRepo.CreateAsync(imageModel);
                }
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