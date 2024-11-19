
using api.DTOs.PColor;

namespace api.DTOs.ProductSize
{
    public class ProductSizeDto
    {
        public int SizeId { get; set; }
        public int ProductId { get; set; }
        public string Name { get; set; } = "";
        public decimal Price { get; set; }
        public decimal Cost { get; set; }
        public int Stock { get; set; }
        public int CategoryId { get; set; }
        public List<ColorDto>? Colors { get; set; }
    }
}