using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;

namespace api.Interfaces
{
    public interface IProductColorRepository
    {
        Task<List<ProductColor>> GetAllAsync();
        Task<ProductColor?> GetByIdAsync(int productId, int colorId);
        Task<ProductColor?> CreateAsync(ProductColor productColorModel);
        Task<ProductColor?> DeleteAsync(int productId, int colorId);
    }
}