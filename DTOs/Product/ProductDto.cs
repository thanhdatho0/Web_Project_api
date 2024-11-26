using api.DTOs.Material;
using api.DTOs.PColor;
using api.DTOs.Size;

namespace api.DTOs.Product;

public class ProductDto
{
    public int ProductId { get; set; }
    public string Name { get; set; } = "";
    public string? SubcategoryName { get; set; } = "";
    public decimal Price { get; set; }
    public string? Description { get; set; }
    public decimal Cost { get; set; }
    public decimal DiscountPercentage { get; set; }
    public int InStock { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public int SubcategoryId { get; set; }
    public int ProviderId { get; set; }
    public List<SizeDto>? Sizes { get; set; }
    public List<MaterialDto>? Materials { get; set; }
    public List<ColorDto>? Colors { get; set; }
}