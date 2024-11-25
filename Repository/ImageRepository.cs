using System.Reflection.Metadata.Ecma335;
using api.Data;
using api.DTOs.PImage;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class ImageRepository : IImageRepository
    {
        private readonly ApplicationDbContext _context;

        public ImageRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Image?> CreateAsync(Image imageModel)
        {
            await _context.Images.AddAsync(imageModel);
            await _context.SaveChangesAsync();
            return imageModel;
        }

        public async Task<Image?> DeleteAsync(int id)
        {
            var image = await _context.Images.FirstOrDefaultAsync(i => i.ImageId == id);

            if (image == null)
                return null;

            _context.Images.Remove(image);

            await _context.SaveChangesAsync();

            return image;
        }

        public async Task<List<Image>> GetAllAsync()
        {
            return await _context.Images.ToListAsync();
        }

        public async Task<Image?> GetByIdAsync(int id)
        {
            return await _context.Images.FindAsync(id);
        }

        public async Task<Image?> UpdateAsync(int id, ImageUpdateDto imageDto)
        {
            var image = await _context.Images.FirstOrDefaultAsync(x => x.ImageId == id);

            if (image == null)
                return null;

            image.Url = imageDto.Url;
            image.Alt = imageDto.Alt;

            await _context.SaveChangesAsync();
            return image;
        }
    }
}