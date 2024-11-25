using api.Data;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository;

public class ProductMaterialRepository : IProductMaterialRepository
{
    private readonly ApplicationDbContext _context;

    public ProductMaterialRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<List<ProductMaterial>> GetAllAsync()
    {
        return await _context.ProductMaterials.ToListAsync();
    }

    public async Task<ProductMaterial?> GetByIdAsync(int productId, int materialId)
    {
        throw new NotImplementedException();
    }

    public async Task<ProductMaterial?> CreateAsync(ProductMaterial productMaterialModel)
    {
        await _context.ProductMaterials.AddAsync(productMaterialModel);
        await _context.SaveChangesAsync();
        return productMaterialModel;
    }

    public async Task<ProductMaterial?> DeleteAsync(int productId, int materialId)
    {
        throw new NotImplementedException();
    }
}