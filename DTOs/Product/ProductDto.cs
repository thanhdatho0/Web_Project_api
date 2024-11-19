using api.DTOs.PColor;
using api.DTOs.Size;

namespace api.DTOs.Product;

public class ProductDto
{
    public int ProductId { get; set; }
    public string Name { get; set; } = "";
    public string CategoryName { get; set; } = "";
    public decimal Price { get; set; }
    public string? Description { get; set; }
    public decimal Cost { get; set; }
    public int Stock { get; set; }
    public bool isDeleted { get; set; }
    public int CategoryId { get; set; }
    public int ProviderId { get; set; }
    public List<SizeDto>? Sizes { get; set; }
    public List<ColorDto>? Colors { get; set; }
}