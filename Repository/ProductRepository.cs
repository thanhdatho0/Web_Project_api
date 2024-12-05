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
    // Bắt đầu truy vấn với IQueryable để tận dụng EF Core
    var products = context.Products
        .Include(p => p.Subcategory)
            .ThenInclude(s => s!.Category)
        .Include(p => p.Inventories)
            .ThenInclude(pc => pc.Color)
            .ThenInclude(c => c!.Images)
        .Include(p => p.Inventories)
            .ThenInclude(pz => pz.Size)
        .AsQueryable();

    // Áp dụng bộ lọc cho TargetCustomerId, CategoryId, và SubcategoryId
    if (query.TargetCustomerId is not null)
        products = products.Where(p => p.Subcategory!.Category!.TargetCustomerId == query.TargetCustomerId);

    if (query.CategoryId is not null)
        products = products.Where(p => p.Subcategory!.CategoryId == query.CategoryId);

    if (query.SubcategoryId is not null)
        products = products.Where(p => p.SubcategoryId == query.SubcategoryId);

    // Lọc theo ColorId
    if (!string.IsNullOrEmpty(query.ColorId))
    {
        var colorIds = query.ColorId.Split(',')
                                    .Select(int.Parse)
                                    .ToList();

        products = products.Where(p => p.Inventories.Any(pc => colorIds.Contains(pc.ColorId)));
    }

    // Lọc theo SizeId
    if (!string.IsNullOrEmpty(query.SizeId))
    {
        var sizeIds = query.SizeId.Split(',')
                                  .Select(int.Parse)
                                  .ToList();

        products = products.Where(p => p.Inventories.Any(pc => sizeIds.Contains(pc.SizeId)));
    }

    // Lọc theo Price
    if (!string.IsNullOrEmpty(query.Price))
    {
        var priceRanges = query.Price.Split(',');

        products = priceRanges.Aggregate(products, (current, priceRange) => priceRange switch
        {
            "duoi-350" => current.Where(p => p.Price < 350000),
            "350-750" => current.Where(p => p.Price >= 350000 && p.Price <= 750000),
            "tren-750" => current.Where(p => p.Price > 750000),
            _ => current
        });
    }

    // Sắp xếp
    if (!string.IsNullOrEmpty(query.SortBy))
    {
        products = query.SortBy switch
        {
            "date" => products.OrderByDescending(p => p.UpdatedAt),
            "low" => products.OrderBy(p => p.Price),
            "high" => products.OrderByDescending(p => p.Price),
            "trend" => products
                .Include(p => p.Inventories)
                .ThenInclude(i => i.OrderDetails)
                .OrderByDescending(p => p.Inventories
                    .SelectMany(i => i.OrderDetails)
                    .Sum(od => od.Amount)),
            _ => products.OrderByDescending(p => p.CreatedAt)
        };
    }

    // Phân trang
    var skipNumber = (query.PageNumber - 1) * query.PageSize;

    // Truy vấn dữ liệu từ cơ sở dữ liệu
    return await products
        .Skip(skipNumber)
        .Take(query.PageSize)
        .ToListAsync();
}

    public async Task<Product?> GetByIdAsync(int id)
    {
        return await context.Products
            .AsNoTracking()
            .Include(p => p.Subcategory)
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
        var latestQuantity = productUpdateDto.Quantity;
        product.ToProductFromUpdateDto(productUpdateDto);
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
