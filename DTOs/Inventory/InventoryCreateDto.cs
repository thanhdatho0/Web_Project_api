namespace api.DTOs.Inventory;

public class InventoryCreateDto
{
    public int ProductId { get; set; }
    public int ColorId { get; set; }
    public int SizeId { get; set; }
    public int Quantity { get; set; }
}