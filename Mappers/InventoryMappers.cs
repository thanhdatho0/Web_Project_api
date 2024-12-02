
using api.DTOs.Inventory;
using api.Models;

namespace api.Mappers
{
    public static class InventoryMappers
    {
        public static InventoryDto ToInventoryDto(this Inventory inventory)
        {
            return new InventoryDto
            {
                Quantity = inventory.Quantity,
                InStock = inventory.InStock
            };
        }
    }
}