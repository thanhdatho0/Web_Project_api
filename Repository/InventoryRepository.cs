using api.Data;
using api.Interfaces;
using api.Models;

namespace api.Repository;

public class InventoryRepository(ApplicationDbContext context) : IInventoryRepository
{
    
    public async Task<List<Inventory>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<Inventory> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<Inventory> CreateAsync(Inventory inventory)
    {
        await context.Inventories.AddAsync(inventory);
        await context.SaveChangesAsync();
        return inventory;
    }

    public async Task<Inventory> UpdateAsync(Inventory inventory)
    {
        throw new NotImplementedException();
    }
}