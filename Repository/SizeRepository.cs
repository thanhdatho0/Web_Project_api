
using api.Data;
using Microsoft.EntityFrameworkCore;
using api.DTOs.Size;
using api.Interfaces;
using api.Mappers;
using api.Models;

namespace api.Repository
{
    public class SizeRepository(ApplicationDbContext context) : ISizeRepository
    {
        public async Task<Size> CreateAsync(Size size)
        {
            await context.Sizes.AddAsync(size);
            await context.SaveChangesAsync();
            return size;
        }

        public async Task<Size?> DeleteAsync(int id)
        {
            var size = await context.Sizes.FirstOrDefaultAsync(x => x.SizeId == id);

            if (size == null)
                return null;

            context.Sizes.Remove(size);

            await context.SaveChangesAsync();

            return size;
        }

        public async Task<List<Size>> GetAllAsync()
        {
            return await context.Sizes.ToListAsync();
        }

        public async Task<Size?> GetByIdAsync(int id)
        {
            return await context.Sizes.FindAsync(id);
        }

        public Task<bool> SizeExists(int id)
        {
            return context.Sizes.AnyAsync(p => p.SizeId == id);
        }

        public async Task<Size?> UpdateAsync(int id, SizeUpdateDto sizeUpdateDto)
        {
            var size = await context.Sizes.FirstOrDefaultAsync(x => x.SizeId == id);
            if (size == null)
                return null;
            size.ToSizeFromUpdateDto(sizeUpdateDto);
            await context.SaveChangesAsync();
            return size;
        }
    }
}