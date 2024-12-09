
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
        ICategoryRepository categoryRepo,
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
        public async Task<IActionResult> Create([FromBody] ProductCreateDto productCreateDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // var isSubCategoryExists = await subcategoryRepo.SubcategoryExists(productCreateDto.SubcategoryId);
            // if (!isSubCategoryExists)
            // {
            //     var subcategory = 
            // }
            //     await subcategoryRepo.CreateAsync()

            if (productCreateDto.newCategory != null)
            {
                var category = new Category
                {
                    TargetCustomerId = productCreateDto.TargetCustomerId,
                    Name = productCreateDto.newCategory
                };
                await categoryRepo.CreateAsync(category);
            }

            if (productCreateDto.newSubcategory != null)
            {
                var subCategory = new Subcategory
                {
                    CategoryId = productCreateDto.CategoryId,
                    SubcategoryName = productCreateDto.newSubcategory,
                };
                await subcategoryRepo.CreateAsync(subCategory);
            }
            
            var isProviderExists = await providerRepo.ProviderExists(productCreateDto.ProviderId);
            if (!isProviderExists)
                return BadRequest("Provider does not exists!");
            
            var isProductExists = await productRepo.ProductNameExists(productCreateDto.Name);
            if(isProductExists)
               return BadRequest("Product already exists!"); 

            var productModel = productCreateDto.ToProductFromCreateDto();
            productModel.Quantity = productCreateDto.Inventory.Select(p => p.Sizes.Select(s => s.Quantity).Sum()).Sum();
            productModel.InStock = productModel.Quantity;
            
            await productRepo.CreateAsync(productModel);
            foreach (var inventoryCreateDto in productCreateDto.Inventory)
            {
                var inventory = new Inventory
                {
                    ProductId = productModel.ProductId, 
                    ColorId = inventoryCreateDto.Color.ColorId, 
                };
                foreach (var sizes in inventoryCreateDto.Sizes)
                {
                    inventory.SizeId = sizes.SizeId;
                    inventory.Quantity = sizes.Quantity;
                    inventory.InStock = sizes.Quantity;
                    await inventoryRepo.CreateAsync(inventory);
                }
            }

            foreach (var color in productCreateDto.Inventory.Select(x => x.Color).Distinct())
            {
                foreach (var image in color.Images!)
                {
                    var imageModel = image.ToImageFromCreateProductDto();
                    imageModel.ColorId = color.ColorId;
                    imageModel.ProductId = productModel.ProductId;
                    await imageRepo.CreateAsync(imageModel);
                }
            }
            return Ok(productCreateDto.ToProductFromCreateDto());
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