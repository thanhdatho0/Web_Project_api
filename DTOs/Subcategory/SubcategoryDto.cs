
using api.DTOs.Product;

namespace api.DTOs.Subcategory
{
    public class SubcategoryDto
    {
        public int SubcategoryId { get; set; }
        public string? SubcategoryName { get; set; }
        public string? Description { get; set; }
        // public List<ProductDto>? Products { get; set; }
        // public int CategoryId { get; set; }
    }
}