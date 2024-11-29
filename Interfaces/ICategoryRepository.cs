
using api.DTOs.Category;
using api.Models;
using api.Helpers;

namespace api.Interfaces
{
    public interface ICategoryRepository
    {
        Task<List<Category>?> GetAllAsync(QueryOject query);
        Task<Category?> GetByIdAsync(int id);
        Task<Category> CreateAsync(Category category);
        Task<Category?> UpdateAsync(int id, CategoryUpdateDto categoryUpdateDto);
        // Task<Category?> DeleteAsync(int id);
        Task<bool> CategoryExists(int id);
        // Task<bool> CategoryName(string name);
    }
}