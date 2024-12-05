
using api.Data;
using api.DTOs.Category;
using api.Interfaces;
using api.Helpers;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class CategoryRepository(ApplicationDbContext context) : ICategoryRepository
    {
        public Task<bool> CategoryExists(int id)
        {
            return context.Categories.AnyAsync(c => c.CategoryId == id);
        }

        public async Task<Category> CreateAsync(Category category)
        {
            await context.Categories.AddAsync(category);
            await context.SaveChangesAsync();
            return category;
        }

        public async Task<List<Category>?> GetAllAsync(QueryOject query)
        {
            var categories = context.Categories.Include(c => c.Subcategories).AsNoTracking();

            if (!string.IsNullOrEmpty(query.Name))
                categories = categories.Where(c => c.Name == query.Name);

            return await categories.ToListAsync();
        }

        public async Task<Category?> GetByIdAsync(int id)
        {
            return await context.Categories.AsNoTracking().Include(c => c.Subcategories).FirstOrDefaultAsync(c => c.CategoryId == id);
        }

        public async Task<Category?> UpdateAsync(int id, CategoryUpdateDto categoryUpdateDto)
        {
            var category = await context.Categories.FirstOrDefaultAsync(x => x.CategoryId == id);

            if (category == null)
                return null;

            category.Name = categoryUpdateDto.Name;
            await context.SaveChangesAsync();
            return category;
        }
    }
}