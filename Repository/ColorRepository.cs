using api.Data;
using api.DTOs.PColor;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class ColorRepository : IColorRepository
    {
        private readonly ApplicationDbContext _context;
        public ColorRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Color> CreateAsync(Color color)
        {
            await _context.Colors.AddAsync(color);
            await _context.SaveChangesAsync();
            return color;
        }
        public async Task<Color?> DeleteAsync(int id)
        {
            var color = await _context.Colors.FirstOrDefaultAsync(c => c.ColorId == id);
            if (color == null) return null;
            _context.Colors.Remove(color);
            await _context.SaveChangesAsync();
            return color;
        }

        public async Task<List<Color>> GetAllAsync()
        {
            return await _context.Colors.ToListAsync();
        }

        public async Task<Color?> GetByIdAsync(int id)
        {
            return await _context.Colors.FindAsync(id);
        }

        public async Task<Color?> UpdateAsync(int id, ColorUpdateDto colorUpdateDto)
        {
            var color = await _context.Colors.FirstOrDefaultAsync(c => c.ColorId == id);
            if (color == null) return null;
            color.HexaCode = colorUpdateDto.HexaCode;
            color.Name = colorUpdateDto.Name;
            await _context.SaveChangesAsync();
            return color;
        }
    }
}