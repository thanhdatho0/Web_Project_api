using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;

namespace api.Interfaces
{
    public interface IProductSizeRepository
    {
        Task<List<ProductSize>> GetAllAsync();
        Task<ProductSize?> GetByIdAsync(int productId, int sizeId);
        Task<ProductSize?> CreateAsync(ProductSize productColorModel);
        Task<ProductSize?> DeleteAsync(int productId, int sizeId);
    }
}