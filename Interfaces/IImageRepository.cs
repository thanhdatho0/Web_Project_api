using api.DTOs.PImage;
using api.Models;

namespace api.Interfaces
{
    public interface IImageRepository
    {
        Task<List<Image>> GetAllAsyns();
        Task<Image?> GetByIdAsyns(int id);
        Task<Image?> CreateAsyns(Image imageModel);
        Task<Image?> UpdateAsyns(int id, ImageUpdateDto imageUpdateDto);
        Task<Image?> DeleteAsync(int id);
    }
}