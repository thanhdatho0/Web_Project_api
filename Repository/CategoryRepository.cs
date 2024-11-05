using api.Data;
using api.DTOs.Category;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{

    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _context;
        public CategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Category>> GetAllAsync()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<Category?> GetByIdAsync(int id)
        {
            return await _context.Categories.FindAsync(id);
        }

        public async Task<Category> CreateAsync(Category category)
        {
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
            return category;
        }

        public async Task<Category?> UpdateAsync(int id, CategoryUpdateDto categoryUpdateDTO)
        {
            var category = await _context.Categories.FirstOrDefaultAsync(x => x.CategoryId == id);
            if (category == null) return null;
            category.Name = categoryUpdateDTO.Name;
            category.Description = categoryUpdateDTO.Description;
            await _context.SaveChangesAsync();
            return category;
        }

        public async Task<Category?> DeleteAsync(int id)
        {
            var category = await _context.Categories.FirstOrDefaultAsync(x => x.CategoryId == id);
            if (category == null) return null;
            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
            return category;
        }
    }
}