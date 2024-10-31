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
    private readonly ApplicationDbContext _context;
    private readonly IProductRepository _productRepo;

    public ProductController(ApplicationDbContext context, IProductRepository productRepo)
    {
        _context = context;
        _productRepo = productRepo;
    }

    [HttpGet]
    public async Task<ActionResult> GetAllProducts()
    
    {
        var products = await _productRepo.GetAllAsync();
        var productsDto = products.Select(x => x.ToProductDto());
        return Ok(productsDto);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult> GetProductById(int id)
    {
        var product = await _productRepo.GetByIdAsync(id);
        if(product == null) return NotFound();
        return Ok(product.ToProductDto());
    }

    [HttpPost]
    public async Task<ActionResult> Create([FromBody] ProductCreateDto productDto)
    {
        var product = productDto.ToProductFromCreateDto();
        await _productRepo.CreateAsync(product);
        return CreatedAtAction(nameof(GetProductById), new {id = product.ProductId}, product.ToProductDto());
    }
    
    [HttpPut]
    [Route("{id}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] ProductUpdateDto productDto){
        var product = await _productRepo.UpdateAsync(id, productDto);
        return Ok(product?.ToProductDto());
    }

    [HttpDelete]
    [Route("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id){
        var product = await _productRepo.DeleteAsync(id);
        if(product == null) return NotFound();
        return NoContent();
    }
    
}