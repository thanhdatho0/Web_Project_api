using api.Data;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{

    public class ProductColorRepository(ApplicationDbContext context) : IProductColorRepository
    {
        public Task<List<ProductColor>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<ProductColor?> GetByIdAsync(int productId, int colorId)
        {
            return await context.ProductColors.Include(pc => pc.Product).Include(pc => pc.Color).FirstOrDefaultAsync(pc => pc.ColorId == colorId && pc.ProductId == productId);
        }
        public async Task<ProductColor?> CreateAsync(ProductColor productColorModel)
        {
            await context.ProductColors.AddAsync(productColorModel);
            await context.SaveChangesAsync();
            return productColorModel;
        }

        public async Task<ProductColor?> DeleteAsync(int productId, int colorId)
        {
            var productColorModel = await context.ProductColors.FirstOrDefaultAsync(pc => pc.ColorId == colorId && pc.ProductId == productId);

            if (productColorModel == null)
                return null;

            context.ProductColors.Remove(productColorModel);
            await context.SaveChangesAsync();
            return productColorModel;

        }
    }
}