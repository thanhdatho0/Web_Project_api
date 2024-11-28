using api.Data;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository;

public class ProductMaterialRepository(ApplicationDbContext context) : IProductMaterialRepository
{
    public async Task<List<ProductMaterial>> GetAllAsync()
    {
        return await context.ProductMaterials.ToListAsync();
    }

    public async Task<ProductMaterial?> GetByIdAsync(int productId, int materialId)
    {
        throw new NotImplementedException();
    }

    public async Task<ProductMaterial?> CreateAsync(ProductMaterial productMaterialModel)
    {
        await context.ProductMaterials.AddAsync(productMaterialModel);
        await context.SaveChangesAsync();
        return productMaterialModel;
    }

    public async Task<ProductMaterial?> DeleteAsync(int productId, int materialId)
    {
        throw new NotImplementedException();
    }
}