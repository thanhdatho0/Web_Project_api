using api.DTOs.Subcategory;
using api.Helpers;
using api.Models;

namespace api.Interfaces
{
    public interface ISubcategoryRepository
    {
        Task<List<Subcategory>> GetAllAsync(QueryOject query);
        Task<Subcategory?> GetByIdAsync(int id);
        Task<Subcategory> CreateAsync(Subcategory subcategory);
        Task<Subcategory?> UpdateAsync(int id, SubcategoryUpdateDto subcategoryUpdateDto);
        // Task<Subcategory?> DeleteAsync(int id);
        Task<bool> SubcategoryExists(int id);
        Task<bool> SubcategoryName(string name);
    }
}