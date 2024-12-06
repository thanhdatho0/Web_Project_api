
using api.Data;
using api.DTOs.PImage;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class ImageRepository(ApplicationDbContext context) : IImageRepository
    {
        public async Task<Image?> CreateAsync(Image imageModel)
        {
            Console.WriteLine(imageModel.ImageId);
            await context.Images.AddAsync(imageModel);
            await context.SaveChangesAsync();
            return imageModel;
        }

        public async Task<Image?> DeleteAsync(int id)
        {
            var image = await context.Images.FirstOrDefaultAsync(i => i.ImageId == id);

            if (image == null)
                return null;

            context.Images.Remove(image);

            await context.SaveChangesAsync();

            return image;
        }

        public async Task<List<Image>> GetAllAsync()
        {
            return await context.Images.ToListAsync();
        }

        public async Task<Image?> GetByIdAsync(int id)
        {
            return await context.Images.FindAsync(id);
        }

        public async Task<Image?> UpdateAsync(int id, ImageUpdateDto imageDto)
        {
            var image = await context.Images.FirstOrDefaultAsync(x => x.ImageId == id);

            if (image == null)
                return null;

            image.Url = imageDto.Url;
            image.Alt = imageDto.Alt;

            await context.SaveChangesAsync();
            return image;
        }
    }
}