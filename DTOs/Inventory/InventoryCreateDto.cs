using api.DTOs.PColor;

namespace api.DTOs.Inventory;

public class InventoryCreateDto
{
    public ColorToProductDto Color { get; set; }
    public int SizeId { get; set; }
    public int Quantity { get; set; }
}