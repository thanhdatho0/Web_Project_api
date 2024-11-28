using api.Data;
using api.DTOs.Product;
using api.Helpers;
using api.Interfaces;
using api.Mappers;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository;

public class ProductRepository(ApplicationDbContext context) : IProductRepository
{
    public async Task<List<Product>> GetAllAsync(ProductQuery query)
    {
        var products = context.Products.Include(p => p.Subcategory)
                                .Include(p => p.ProductSizes)
                                .ThenInclude(pz => pz.Size)
                                .Include(p => p.ProductMaterials)
                                .ThenInclude(pm => pm.Material)
                                .Include(p => p.ProductColors)
                                .ThenInclude(pc => pc.Color)
                                .ThenInclude(c => c!.Images).AsQueryable();


        if (!string.IsNullOrEmpty(query.SubcategoryId))
            products = products.Where(p => p.SubcategoryId == int.Parse(query.SubcategoryId));

        var skipNumber = (query.PageNumber - 1) * query.PageSize;

        return await products.Skip(skipNumber).Take(query.PageSize).ToListAsync();
    }

    public async Task<Product?> GetByIdAsync(int id)
    {
        return await context.Products.Include(p => p.Subcategory)
                            .Include(p => p.ProductSizes)
                            .ThenInclude(pz => pz.Size)
                            .Include(p => p.ProductColors)
                            .ThenInclude(pc => pc.Color)
                            .ThenInclude(c => c!.Images)
                            .FirstOrDefaultAsync(p => p.ProductId == id);
    }

    public async Task<Product> CreateAsync(Product productModel)
    {
        await context.Products.AddAsync(productModel);
        await context.SaveChangesAsync();
        return productModel;
    }

    public async Task<Product?> UpdateAsync(int id, ProductUpdateDto productUpdateDto)
    {
        var product = await context.Products.FirstOrDefaultAsync(x => x.ProductId == id);
        if (product == null)
            return null;

        // product.Name = productUpdateDto.Name;
        // product.Description = productUpdateDto.Description;
        // product.Cost = productUpdateDto.Cost;
        // product.Price = productUpdateDto.Price;
        // product.InStock = productUpdateDto.InStock;
        // product.DiscountPercentage = productUpdateDto.DiscountPercentage;
        // product.UpdatedAt = DateTime.Now;
        int latestQuantity = productUpdateDto.Quantity;
        product = productUpdateDto.ToProductFromUpdateDto(); 
        product.InStock += (product.Quantity - latestQuantity);
        await context.SaveChangesAsync();
        return product;
    }

    public async Task<Product?> DeleteAsync(int id)
    {
        var product = await context.Products.FirstOrDefaultAsync(x => x.ProductId == id);

        if (product == null)
            return null;

        context.Products.Remove(product);

        await context.SaveChangesAsync();

        return product;
    }

    public Task<bool> ProductExists(int id)
    {
        return context.Products.AnyAsync(p => p.ProductId == id);

    }
}
