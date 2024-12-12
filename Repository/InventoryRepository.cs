using api.Data;
using api.DTOs.Inventory;
using api.Helpers;
using api.Interfaces;
using api.Mappers;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository;

public class InventoryRepository(ApplicationDbContext context) : IInventoryRepository
{

    public async Task<Inventory?> GetByIdAsync(int id)
    {
        var inventory = await context.Inventories
            .Include(i => i.Product)
            .Include(i => i.Color)
            .Include(i => i.Size)
            .FirstOrDefaultAsync(i => i.InventoryId == id);
        return inventory ?? null;
    }

    public async Task<Inventory?> CreateAsync(Inventory inventory)
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
            i => i.ProductId == productId && i.ColorId == colorId && i.SizeId == sizeId);
        Console.WriteLine(inventory?.InventoryId);
        return inventory ?? null;
    }

    public Task<bool> InventoryExist(int productId, int colorId, int sizeId)
    {
        return context.Inventories.AnyAsync(i =>
                                        i.ProductId == productId &&
                                        i.ColorId == colorId &&
                                        i.SizeId == sizeId);
    }

    public async Task<List<Inventory>?> GetAllAsync(InventoryQuery query)
    {
        var inventories = context.Inventories.AsNoTracking();

        if (query.ProductId is not null)
            inventories = inventories.Where(i => i.ProductId == query.ProductId);

        if (query.ColorId is not null)
            inventories = inventories.Where(i => i.ColorId == query.ColorId);

        if (query.SizeId is not null)
            inventories = inventories.Where(i => i.SizeId == query.SizeId);

        return await inventories.ToListAsync();
    }
}