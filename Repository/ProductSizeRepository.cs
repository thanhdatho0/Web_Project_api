
using api.Data;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class ProductSizeRepository(ApplicationDbContext context) : IProductSizeRepository
    {
        public async Task<ProductSize?> CreateAsync(ProductSize productSizeModel)
        {
            await context.ProductSizes.AddAsync(productSizeModel);
            await context.SaveChangesAsync();
            return productSizeModel;
        }

        public async Task<ProductSize?> DeleteAsync(int productId, int sizeId)
        {
            var productSizeModel = await context.ProductSizes.FirstOrDefaultAsync(pc => pc.SizeId == sizeId && pc.ProductId == productId);

            if (productSizeModel == null)
                return null;

            context.ProductSizes.Remove(productSizeModel);
            await context.SaveChangesAsync();
            return productSizeModel;
        }

        public Task<List<ProductSize>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<ProductSize?> GetByIdAsync(int productId, int sizeId)
        {
            return await context.ProductSizes.FirstOrDefaultAsync(pc => pc.SizeId == sizeId && pc.ProductId == productId);
        }
    }
}