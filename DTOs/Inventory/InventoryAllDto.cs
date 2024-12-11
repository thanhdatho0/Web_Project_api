
namespace api.DTOs.Inventory;

public class InventoryAllDto
{
    public int InventoryId { get; set; }
    public int ProductId { get; set; }
    public int ColorId { get; set; }
    public int SizeId { get; set; }
    public int Quantity { get; set; }
    public int InStock { get; set; }
}