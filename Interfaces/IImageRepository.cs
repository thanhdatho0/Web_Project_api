using api.DTOs.PImage;
using api.Models;

namespace api.Interfaces
{
    public interface IImageRepository
    {
        Task<List<Image>> GetAllAsync();
        Task<Image?> GetByIdAsync(int id);
        Task<Image?> CreateAsync(Image imageModel);
        Task<Image?> UpdateAsync(int id, ImageUpdateDto imageUpdateDto);
        Task<Image?> DeleteAsync(int id);
    }
}