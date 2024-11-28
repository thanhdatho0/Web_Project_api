using api.Data;
using api.DTOs.Material;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository;

public class MaterialRepository(ApplicationDbContext context) : IMaterialRepository
{
    public async Task<List<Material>> GetAllAsync()
    {
        return await context.Materials.ToListAsync();
    }

    public async Task<Material?> GetByIdAsync(int materialId)
    {
        return await context.Materials.FindAsync(materialId);
    }

    public async Task<Material?> CreateAsync(Material material)
    {
        await context.Materials.AddAsync(material);
        await context.SaveChangesAsync();
        return material;
    }

    public async Task<Material?> UpdateAsync(int id, MaterialCreateDto materialCreateDto)
    {
        var material = context.Materials.FirstOrDefault(x => x.MaterialId == id);
        if (material == null) return null;
        material.MaterialType = materialCreateDto.MaterialType;
        await context.SaveChangesAsync();
        return material;
    }

    public async Task<Material?> DeleteAsync(int materialId)
    {
        throw new NotImplementedException();
    }
}