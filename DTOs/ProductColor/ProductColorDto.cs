
namespace api.DTOs.ProductColor
{
    public class ProductColorDto
    {
        public int ProductId { get; set; }
        public string Name { get; set; } = "";
        public decimal Price { get; set; }
        public decimal Cost { get; set; }
        public int ColorId { get; set; }
    }
}