using api.DTOs.Product;

namespace api.DTOs.OrderDetail;

public class OrderDetailDto
{
    public string? ProductName { get; set; }
    public decimal ProductPrice { get; set; }
    public string? Size { get; set; }
    public string? Color { get; set; }
    public int Quantity { get; set; }
}