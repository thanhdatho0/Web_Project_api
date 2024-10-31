using api.Data;
using api.DTOs.Product;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository;

public class ProductRepository : IProductRepository
{
    private readonly ApplicationDbContext _context;

    public ProductRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<List<Product>> GetAllAsync()
    {
        return await _context.Products.ToListAsync();
    }

    public async Task<Product?> GetByIdAsync(int id)
    {
        return await _context.Products.FindAsync(id);
    }

    public async Task<Product> CreateAsync(Product product)
    {
        await _context.Products.AddAsync(product);
        await _context.SaveChangesAsync();
        return product;
    }

    public async Task<Product?> UpdateAsync(int id, ProductUpdateDto productUpdateDto)
    {
        var product = await _context.Products.FirstOrDefaultAsync(x => x.ProductId == id);
        if (product == null) return null;
        product.Name = productUpdateDto.Name;
        product.Description = productUpdateDto.Description;
        product.Cost = productUpdateDto.Cost;
        product.Price = productUpdateDto.Price;
        product.Stock = productUpdateDto.Stock;
        return product;
    }

    public async Task<Product?> DeleteAsync(int id)
    {
        var product = await _context.Products.FirstOrDefaultAsync(x => x.ProductId == id);
        if(product == null) return null;
        _context.Products.Remove(product);
        await _context.SaveChangesAsync();
        return product;
    }
}