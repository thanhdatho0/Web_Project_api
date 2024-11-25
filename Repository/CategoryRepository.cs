
using api.Data;
using api.DTOs.Category;
using api.Interfaces;
using api.Helpers;
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

        public Task<bool> CategoryExists(int id)
        {
            return _context.Categories.AnyAsync(c => c.CategoryId == id);
        }

        public async Task<Category> CreateAsync(Category category)
        {
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
            return category;
        }

        public async Task<List<Category>> GetAllAsync(QueryOject query)
        {
            var categories = _context.Categories.Include(c => c.Subcategories).AsQueryable();

            if (!String.IsNullOrEmpty(query.Name))
                categories = categories.Where(c => c.Name == query.Name);

            return await categories.ToListAsync();
        }

        public async Task<Category?> GetByIdAsync(int id)
        {
            return await _context.Categories.Include(c => c.Subcategories).FirstOrDefaultAsync(c => c.CategoryId == id);
        }

        public async Task<Category?> UpdateAsync(int id, CategoryUpdateDto categoryUpdateDto)
        {
            var category = await _context.Categories.FirstOrDefaultAsync(x => x.CategoryId == id);

            if (category == null)
                return null;

            category.Name = categoryUpdateDto.Name;
            await _context.SaveChangesAsync();
            return category;
        }
    }
}