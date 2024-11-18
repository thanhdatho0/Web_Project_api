using System;
using System.Collections.Generic;

using System.Linq;
using System.Threading.Tasks;
using api.Data;
using Microsoft.EntityFrameworkCore;
using api.DTOs.Size;
using api.Interfaces;
using api.Models;

namespace api.Repository
{
    public class SizeRepository : ISizeRepository
    {
        private readonly ApplicationDbContext _context;
        public SizeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Size> CreateAsync(Size size)
        {
            await _context.Sizes.AddAsync(size);
            await _context.SaveChangesAsync();
            return size;
        }

        public async Task<Size?> DeleteAsync(int id)
        {
            var size = await _context.Sizes.FirstOrDefaultAsync(x => x.SizeId == id);

            if (size == null)
                return null;

            _context.Sizes.Remove(size);

            await _context.SaveChangesAsync();

            return size;
        }

        public async Task<List<Size>> GetAllAsync()
        {
            return await _context.Sizes.Include(c => c.ProductSizes).ToListAsync();
        }

        public async Task<Size?> GetByIdAsync(int id)
        {
            return await _context.Sizes.FindAsync(id);
        }

        public Task<bool> SizeExists(int id)
        {
            return _context.Sizes.AnyAsync(p => p.SizeId == id);
        }

        public async Task<Size?> UpdateAsync(int id, SizeUpdateDto sizeUpdateDto)
        {
            var size = await _context.Sizes.FirstOrDefaultAsync(x => x.SizeId == id);
            if (size == null)
                return null;
            size.SizeValue = sizeUpdateDto.SizeValue;
            await _context.SaveChangesAsync();
            return size;
        }
    }
}