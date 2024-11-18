using api.Data;
using api.DTOs.Product;
using api.Helpers;
using api.Interfaces;
using api.Mappers;
using api.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace api.Repository;

public class ProductRepository : IProductRepository
{
    private readonly ApplicationDbContext _context;

    public ProductRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<List<Product>> GetAllAsync(ProductQuery query)
    {
        var products = _context.Products.Include(p => p.Category)
                                .Include(p => p.ProductColors)!
                                .ThenInclude(pc => pc.Color)
                                .ThenInclude(c => c!.Images).AsQueryable();
          

        if (!String.IsNullOrEmpty(query.CategoryId))
            products = products.Where(p => p.CategoryId == int.Parse(query.CategoryId));

        var skipNumber = (query.PageNumber - 1) * query.PageSize;

        return await products.Skip(skipNumber).Take(query.PageSize).ToListAsync();
    }

    public async Task<Product?> GetByIdAsync(int id)
    {
        return await _context.Products.Include(p => p.Category)
                .Include(p => p.ProductColors)
                .ThenInclude(pc => pc.Color)
                .ThenInclude(c => c.Images)
                .FirstOrDefaultAsync(p => p.ProductId == id);
    }

    public async Task<Product> CreateAsync(Product productModel)
    {
        await _context.Products.AddAsync(productModel);
        await _context.SaveChangesAsync();
        return productModel;
    }

    public async Task<Product?> UpdateAsync(int id, ProductUpdateDto productUpdateDto)
    {
        var product = await _context.Products.FirstOrDefaultAsync(x => x.ProductId == id);
        if (product == null)
            return null;

        product.Name = productUpdateDto.Name;
        product.Description = productUpdateDto.Description;
        product.Cost = productUpdateDto.Cost;
        product.Price = productUpdateDto.Price;
        product.Stock = productUpdateDto.Stock;
        await _context.SaveChangesAsync();
        return product;
    }

    public async Task<Product?> DeleteAsync(int id)
    {
        var product = await _context.Products.FirstOrDefaultAsync(x => x.ProductId == id);

        if (product == null)
            return null;

        _context.Products.Remove(product);

        await _context.SaveChangesAsync();

        return product;
    }

    public Task<bool> ProductExists(int id)
    {
        return _context.Products.AnyAsync(p => p.ProductId == id);

    }
}
