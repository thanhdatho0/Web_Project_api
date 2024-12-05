using api.Data;
using api.DTOs.PColor;
using api.Interfaces;
using api.Mappers;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class ColorRepository(ApplicationDbContext context) : IColorRepository
    {
        public Task<bool> ColorExists(int id)
        {
            return context.Colors.AnyAsync(c => c.ColorId == id);
        }

        public async Task<Color> CreateAsync(Color color)
        {
            await context.Colors.AddAsync(color);
            await context.SaveChangesAsync();
            return color;
        }
        public async Task<Color?> DeleteAsync(int id)
        {
            var color = await context.Colors.FirstOrDefaultAsync(c => c.ColorId == id);
            if (color == null) return null;
            context.Colors.Remove(color);
            await context.SaveChangesAsync();
            return color;
        }

        public async Task<List<Color>?> GetAllAsync()
        {
            return await context.Colors.AsNoTracking().Include(c => c.Images).ToListAsync();
        }

        public async Task<Color?> GetByIdAsync(int id)
        {
            return await context.Colors.AsNoTracking().FirstOrDefaultAsync(c => c.ColorId == id);
        }

        public async Task<Color?> UpdateAsync(int id, ColorUpdateDto colorUpdateDto)
        {
            var color = await context.Colors.FirstOrDefaultAsync(c => c.ColorId == id);
            if (color == null) return null;
            color.ToColorFromUpdateDto(colorUpdateDto);
            await context.SaveChangesAsync();
            return color;
        }
    }
}