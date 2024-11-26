using api.Data;
using api.DTOs.Subcategory;
using api.Helpers;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{

    public class SubcategoryRepository : ISubcategoryRepository
    {
        private readonly ApplicationDbContext _context;
        public SubcategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Subcategory>> GetAllAsync(QueryOject query)
        {
            var subcategories = _context.Subcategories.AsQueryable();

            if (!String.IsNullOrEmpty(query.Name))
                subcategories = subcategories.Where(c => c.SubcategoryName == query.Name);

            return await subcategories.ToListAsync();
        }

        public async Task<Subcategory?> GetByIdAsync(int id)
        {
            return await _context.Subcategories.Include(c => c.Products).FirstOrDefaultAsync(i => i.SubcategoryId == id);
        }

        public async Task<Subcategory> CreateAsync(Subcategory subcategory)
        {
            await _context.Subcategories.AddAsync(subcategory);
            await _context.SaveChangesAsync();
            return subcategory;
        }

        public async Task<Subcategory?> UpdateAsync(int id, SubcategoryUpdateDto subcategoryUpdateDto)
        {
            var subcategory = await _context.Subcategories.FirstOrDefaultAsync(x => x.SubcategoryId == id);
            if (subcategory == null) return null;
            subcategory.SubcategoryName = subcategoryUpdateDto.SubcategoryName;
            subcategory.Description = subcategoryUpdateDto.Description;
            await _context.SaveChangesAsync();
            return subcategory;
        }

        public async Task<Subcategory?> DeleteAsync(int id)
        {
            var subcategory = await _context.Subcategories.FirstOrDefaultAsync(x => x.SubcategoryId == id);
            if (subcategory == null) return null;
            _context.Subcategories.Remove(subcategory);
            await _context.SaveChangesAsync();
            return subcategory;
        }

        public Task<bool> SubcategoryExists(int id)
        {
            return _context.Subcategories.AnyAsync(c => c.SubcategoryId == id);
        }

        public Task<bool> SubcategoryName(string name)
        {
            return _context.Subcategories.AnyAsync(s => s.SubcategoryName == name);
        }
    }
}