
namespace api.DTOs.Product
{
    public class ProductProviderDto
    {
        public int ProductId { get; set; }
        public string Name { get; set; } = "";
        public decimal Price { get; set; }
        public string? Description { get; set; }
        public decimal Cost { get; set; }
        public int Stock { get; set; }
        public bool isDeleted { get; set; }
        public int ProviderId { get; set; }
    }
}