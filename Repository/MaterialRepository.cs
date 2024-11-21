using api.Data;
using api.DTOs.Material;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository;

public class MaterialRepository : IMaterialRepository
{
    private readonly ApplicationDbContext _context;

    public MaterialRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<List<Material>> GetAllAsync()
    {
        return await _context.Materials.ToListAsync();
    }

    public async Task<Material?> GetByIdAsync(int materialId)
    {
        return await _context.Materials.FindAsync(materialId);
    }

    public async Task<Material?> CreateAsync(Material material)
    {
        await _context.Materials.AddAsync(material);
        await _context.SaveChangesAsync();
        return material;
    }

    public async Task<Material?> UpdateAsync(int id, MaterialCreateDto materialCreateDto)
    {
        var material = _context.Materials.FirstOrDefault(x => x.MaterialId == id);
        if (material == null) return null;
        material.MaterialType = materialCreateDto.MaterialType;
        await _context.SaveChangesAsync();
        return material;
    }

    public async Task<Material?> DeleteAsync(int materialId)
    {
        throw new NotImplementedException();
    }
}