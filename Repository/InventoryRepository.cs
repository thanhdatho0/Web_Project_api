using api.Data;
using api.DTOs.Inventory;
using api.Interfaces;
using api.Mappers;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository;

public class InventoryRepository(ApplicationDbContext context) : IInventoryRepository
{
    // public async Task<List<Inventory>> GetAllAsync()
    // {
    //     throw new NotImplementedException();
    // }

    public async Task<Inventory?> GetByIdAsync(int id)
    {
        var inventory = await context.Inventories
            .Include(i => i.Product)
            .Include(i => i.Color)
            .Include(i => i.Size)
            .FirstOrDefaultAsync(i => i.InventoryId == id);
        return inventory ?? null;
    }

    public async Task<Inventory> CreateAsync(Inventory inventory)
    {
        await context.Inventories.AddAsync(inventory);
        await context.SaveChangesAsync();
        return inventory;
    }

    // public async Task<Inventory?> UpdateAsync(int id, InventoryUpdateDto inventoryUpdateDto)
    // {
    //     var inventory = await context.Inventories.FindAsync();
    //     if (inventory == null) return null;
    //     var latestInStock = inventory.InStock;
    //     var latestQuantity = inventory.Quantity;
    //     inventory.ToInventoryFromUpdate(inventoryUpdateDto);
    //     latestInStock += inventoryUpdateDto.Quantity - latestQuantity;
    //     inventory.InStock = latestInStock;
    //     await context.SaveChangesAsync();
    //     return inventory;
    // }

    public async Task<Inventory?> GetByDetailsId(int productId, int colorId, int sizeId)
    {
        var inventory = await context.Inventories.FirstOrDefaultAsync(
            i => i.ProductId == productId
                 && i.ColorId == colorId
                 && i.SizeId == sizeId);
        return inventory ?? null;
    }

    public Task<bool> InventoryExist(int productId, int colorId, int sizeId)
    {
        return context.Inventories.AnyAsync(i =>
                                        i.ProductId == productId &&
                                        i.ColorId == colorId &&
                                        i.SizeId == sizeId);
    }
}