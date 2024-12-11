
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

        public static InventoryAllDto ToInventoryALLDto(this Inventory inventory)
        {
            return new InventoryAllDto
            {
                InventoryId = inventory.InventoryId,
                ProductId = inventory.ProductId,
                ColorId = inventory.ColorId,
                SizeId = inventory.SizeId,
                Quantity = inventory.Quantity,
                InStock = inventory.InStock
            };
        }

        public static Inventory ToInventory(this InventoryCreateDto inventoryCreateDto)
        {
            return new Inventory
            {
                ProductId = inventoryCreateDto.ProductId,
                ColorId = inventoryCreateDto.ColorId,
                SizeId = inventoryCreateDto.SizeId,
                Quantity = inventoryCreateDto.Quantity,
                InStock = inventoryCreateDto.Quantity
            };
        }

        public static void ToInventoryFromUpdate(this Inventory inventory, InventoryUpdateDto inventoryUpdateDto)
        {
            inventory.SizeId = inventoryUpdateDto.SizeId;
            inventory.ColorId = inventoryUpdateDto.ColorId;
            inventory.Quantity = inventoryUpdateDto.Quantity;
        }
    }
}