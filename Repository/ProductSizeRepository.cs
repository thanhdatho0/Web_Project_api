using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class ProductSizeRepository : IProductSizeRepository
    {
        private readonly ApplicationDbContext _context;
        public ProductSizeRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<ProductSize?> CreateAsync(ProductSize productSizeModel)
        {
            await _context.ProductSizes.AddAsync(productSizeModel);
            await _context.SaveChangesAsync();
            return productSizeModel;
        }

        public async Task<ProductSize?> DeleteAsync(int productId, int sizeId)
        {
            var productSizeModel = await _context.ProductSizes.FirstOrDefaultAsync(pc => pc.SizeId == sizeId && pc.ProductId == productId);

            if (productSizeModel == null)
                return null;

            _context.ProductSizes.Remove(productSizeModel);
            await _context.SaveChangesAsync();
            return productSizeModel;
        }

        public Task<List<ProductSize>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<ProductSize?> GetByIdAsync(int productId, int sizeId)
        {
            return await _context.ProductSizes.FirstOrDefaultAsync(pc => pc.SizeId == sizeId && pc.ProductId == productId);
        }
    }
}