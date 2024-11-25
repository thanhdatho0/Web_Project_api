using api.DTOs.Material;
using api.Models;

namespace api.Interfaces;

public interface IMaterialRepository
{
    Task<List<Material>> GetAllAsync();
    Task<Material?> GetByIdAsync(int materialId);
    Task<Material?> CreateAsync(Material material);
    Task<Material?> UpdateAsync(int id, MaterialCreateDto materialCreateDto);
    Task<Material?> DeleteAsync(int materialId);
}