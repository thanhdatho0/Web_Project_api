using api.DTOs.Inventory;
using api.Helpers;
using api.Models;

namespace api.Interfaces;

public interface IInventoryRepository
{
    Task<List<Inventory>?> GetAllAsync(InventoryQuery query);
    // Task<Inventory?> GetByIdAsync(int id);
    Task<Inventory?> CreateAsync(Inventory inventory);
    // Task<Inventory?> UpdateAsync(int id, InventoryUpdateDto inventoryUpdateDto);
    Task<Inventory?> GetByDetailsId(int productId, int colorId, int sizeId);
    Task<bool> InventoryExist(int productId, int colorId, int sizeId);
}