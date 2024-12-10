using api.DTOs.Product;
using api.Helpers;
using api.Models;

namespace api.Interfaces;

public interface IProductRepository
{
    Task<List<Product>> GetAllAsync(ProductQuery query);
    Task<Product?> GetByIdAsync(int id);
    Task<Product> CreateAsync(Product productModel);
    Task<Product?> UpdateAsync(int id, ProductUpdateDto productUpdateDto);
    Task<Product?> DeleteAsync(int id);
    Task<bool> ProductExists(int id);
    Task<bool> ProductNameExists(string name);
    Task<Product?> UpdateAmountAsyns(int id, ProductUpdateAmountDto productAmountDto);
}