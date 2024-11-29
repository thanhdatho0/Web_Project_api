using api.DTOs.PColor;
using api.Models;


namespace api.Interfaces
{
    public interface IColorRepository
    {
        Task<List<Color>?> GetAllAsync();
        Task<Color?> GetByIdAsync(int id);
        Task<Color> CreateAsync(Color color);
        Task<Color?> UpdateAsync(int id, ColorUpdateDto colorUpdateDto);
        Task<Color?> DeleteAsync(int id);
        Task<bool> ColorExists(int id);

    }
}