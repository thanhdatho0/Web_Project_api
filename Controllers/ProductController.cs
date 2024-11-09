using api.Data;
using api.DTOs.Product;
using api.Interfaces;
using api.Mappers;
using api.Models;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;


[Route("api/products")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly IProductRepository _productRepo;
    private readonly ICategoryRepository _categoryRepo;
    private readonly IProviderRepository _providerRepo;

    public ProductController(IProductRepository productRepo, ICategoryRepository categoryRepo, IProviderRepository providerRepo)
    {
        _productRepo = productRepo;
        _categoryRepo = categoryRepo;
        _providerRepo = providerRepo;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllProducts()

    {
        var products = await _productRepo.GetAllAsync();
        var productsDto = products.Select(x => x.ToProductDto());
        return Ok(productsDto);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetProductById(int id)
    {
        var product = await _productRepo.GetByIdAsync(id);
        if (product == null) return NotFound();
        return Ok(product.ToProductDto());
    }

    [HttpPost("{categoryId:int},{providerId:int}")]
    public async Task<IActionResult> Create([FromRoute] int categoryId, [FromRoute] int providerId, [FromBody] ProductCreateDto productDto)
    {
        if (!await _categoryRepo.CategoryExists(categoryId)) return BadRequest("Category does not exist!");
        if (!await _providerRepo.ProviderExists(providerId)) return BadRequest("Provider does not exists!");

        var productModel = productDto.ToProductFromCreateDto(categoryId, providerId);
        await _productRepo.CreateAsync(productModel);
        return CreatedAtAction(nameof(GetProductById), new { id = productModel.ProductId }, productModel.ToProductDto());


    }

    [HttpPut]
    [Route("{id:int}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] ProductUpdateDto productDto)
    {
        var product = await _productRepo.UpdateAsync(id, productDto);
        if (product == null) return NotFound("Product not found");
        return Ok(product.ToProductDto());
    }

    [HttpDelete]
    [Route("{id:int}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        var product = await _productRepo.DeleteAsync(id);
        if (product == null) return NotFound("Product does not exists");
        return NoContent();
    }

}