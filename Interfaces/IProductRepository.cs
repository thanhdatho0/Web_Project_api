using api.DTOs.Product;
using api.Models;

namespace api.Interfaces;

public interface IProductRepository
{
    Task<List<Product>> GetAllAsync();
    Task<Product?> GetByIdAsync(int id);
    Task<Product> CreateAsync(Product product);
    Task<Product?> UpdateAsync(int id, ProductUpdateDto productUpdateDto);
    Task<Product?> DeleteAsync(int id);
}