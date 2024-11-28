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
        var products = _context.Products.Include(p => p.Category)?
                                .Include(p => p.ProductSizes)
                                .ThenInclude(pz => pz.Size)
                                .Include(p => p.ProductMaterials)
                                .ThenInclude(pm => pm.Material)?
                                .Include(p => p.ProductColors)
                                .ThenInclude(pc => pc.Color)
                                .ThenInclude(c => c!.Images).AsQueryable();


        if (!String.IsNullOrEmpty(query.CategoryId))
            products = products.Where(p => p.CategoryId == int.Parse(query.CategoryId));

        if (!string.IsNullOrEmpty(query.ProductId))
            products = products.Where(p => p.ProductId == int.Parse(query.ProductId));

        if (!string.IsNullOrEmpty(query.ColorId))
        {
            var colorIds = query.ColorId.Split(',').Select(int.Parse).ToList();
            products = products.Where(p => colorIds.All(colorId => p.ProductColors.Any(pc => pc.ColorId == colorId)));
        }

        // if (!string.IsNullOrEmpty(query.SizeId))
        //     products = products.Where(p => p.ProductSizes.Any(pc => pc.SizeId == int.Parse(query.SizeId)));
        if (!string.IsNullOrEmpty(query.SizeId))
        {
            var sizeIds = query.SizeId.Split(',').Select(int.Parse).ToList();
            products = products.Where(p => sizeIds.All(sizeId => p.ProductSizes.Any(pc => pc.SizeId == sizeId)));
        }




        if (!string.IsNullOrEmpty(query.Price))
        {
            var price = query.Price.Split(',');
            foreach (var i in price)
            {
                if (i == "duoi-350")
                {
                    products = products.Where(p => p.Price < 350000);
                }
                else if (i == "350.000-750.000")
                {
                    products = products.Where(p => p.Price >= 350000 && p.Price <= 750000);
                }
                else if (i == "tren-750")
                {
                    products = products.Where(p => p.Price > 750000);
                }
            }
        }


        var skipNumber = (query.PageNumber - 1) * query.PageSize;

        return await products.Skip(skipNumber).Take(query.PageSize).ToListAsync();
    }

    public async Task<Product?> GetByIdAsync(int id)
    {
        return await _context.Products.Include(p => p.Category)
                            .Include(p => p.ProductSizes)
                            .ThenInclude(pz => pz.Size)
                            .Include(p => p.ProductColors)
                            .ThenInclude(pc => pc.Color)
                            .ThenInclude(c => c!.Images)
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
