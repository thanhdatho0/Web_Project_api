using api.Data;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{

    public class ProductColorRepository : IProductColorRepository
    {
        private readonly ApplicationDbContext _context;
        public ProductColorRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task<List<ProductColor>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<ProductColor?> GetByIdAsync(int productId, int colorId)
        {
            return await _context.ProductColors.FirstOrDefaultAsync(pc => pc.ColorId == colorId && pc.ProductId == productId);
        }
        public async Task<ProductColor?> CreateAsync(ProductColor productColorModel)
        {
            await _context.ProductColors.AddAsync(productColorModel);
            await _context.SaveChangesAsync();
            return productColorModel;
        }

        public async Task<ProductColor?> DeleteAsync(int productId, int colorId)
        {
            var productColorModel = await _context.ProductColors.FirstOrDefaultAsync(pc => pc.ColorId == colorId && pc.ProductId == productId);

            if (productColorModel == null)
                return null;

            _context.ProductColors.Remove(productColorModel);
            await _context.SaveChangesAsync();
            return productColorModel;

        }
    }
}