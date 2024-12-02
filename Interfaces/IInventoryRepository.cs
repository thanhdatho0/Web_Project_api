using api.DTOs.Inventory;
using api.Models;

namespace api.Interfaces;

public interface IInventoryRepository
{
    // Task<List<Inventory>> GetAllAsync();
    // Task<Inventory?> GetByIdAsync(int id);
    Task<Inventory> CreateAsync(Inventory inventory);
    // Task<Inventory?> UpdateAsync(int id, InventoryUpdateDto inventoryUpdateDto);
    Task<Inventory?> GetByDetailsId(int productId, int colorId, int sizeId);
}