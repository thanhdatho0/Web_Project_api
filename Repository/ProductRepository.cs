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
                                .Include(p => p.Inventories)
                                .ThenInclude(pz => pz.Size)
                                .Include(p => p.Inventories)
                                .ThenInclude(pc => pc.Color)
                                .ThenInclude(c => c!.Images).AsQueryable();

        if (query.SubcategoryId.HasValue)
            products = products.Where(p => p.SubcategoryId == query.SubcategoryId);

        if (!string.IsNullOrEmpty(query.ColorId))
        {
            var colorIds = query.ColorId.Split(',')
                                        .Select(id => int.Parse(id))
                                        .ToList();

            products = products.Where(p => p.Inventories.Any(pc => colorIds.Contains(pc.ColorId)));
        }

        if (!string.IsNullOrEmpty(query.SizeId))
        {
            var colorIds = query.SizeId.Split(',')
                                        .Select(id => int.Parse(id))
                                        .ToList();

            products = products.Where(p => p.Inventories.Any(pc => colorIds.Contains(pc.SizeId)));
        }

        if (!string.IsNullOrEmpty(query.Price))
        {
            var priceRanges = query.Price.Split(',');
            foreach (var priceRange in priceRanges)
            {
                if (priceRange == "duoi-350")
                {
                    products = products.Where(p => p.Price < 350000);
                }
                if (priceRange == "350-750")
                {
                    products = products.Where(p => p.Price >= 350000 && p.Price <= 750000);
                }
                if (priceRange == "tren-750")
                {
                    products = products.Where(p => p.Price > 750000);
                }
            }
        }

        if (!String.IsNullOrEmpty(query.SortBy))
        {
            products = query.SortBy switch
            {
                "date" => products.OrderByDescending(p => p.UpdatedAt),
                "low" => products.OrderBy(p => p.Price),
                "hight" => products.OrderByDescending(p => p.Price),
                "trend" => products
                    .Include(p => p.Inventories)
                    .ThenInclude(i => i.OrderDetails)
                    .AsQueryable()
                    .OrderByDescending(p => p.Inventories
                        .SelectMany(i => i.OrderDetails)
                        .Sum(od => od.Amount)),
                _ => products.OrderByDescending(p => p.CreatedAt)
            };

        }

        var skipNumber = (query.PageNumber - 1) * query.PageSize;

        return await products.Skip(skipNumber).Take(query.PageSize).ToListAsync();
    }

    public async Task<Product?> GetByIdAsync(int id)
    {
        return await context.Products.Include(p => p.Subcategory)
                            .Include(p => p.Inventories)
                            .ThenInclude(pz => pz.Size)
                            .Include(p => p.Inventories)
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
