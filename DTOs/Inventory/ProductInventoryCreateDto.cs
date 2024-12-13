using api.DTOs.PColor;
using api.DTOs.PSize;

namespace api.DTOs.Inventory;

public class ProductInventoryCreateDto
{
    public int ColorId { get; set; } = new();
    public List<SizeOfColorDto> Sizes { get; set; } = [];
}