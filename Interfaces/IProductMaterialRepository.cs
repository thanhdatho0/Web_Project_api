using api.Models;

namespace api.Interfaces;

public interface IProductMaterialRepository
{
    Task<List<ProductMaterial>> GetAllAsync();
    Task<ProductMaterial?> GetByIdAsync(int productId, int materialId);
    Task<ProductMaterial?> CreateAsync(ProductMaterial productMaterialModel);
    Task<ProductMaterial?> DeleteAsync(int productId, int materialId);
}