namespace api.DTOs.OrderDetail;

public class OrderDetailCreateDto
{
    public int ProductId { get; set; }
    public int SizeId { get; set; }
    public int ColorId { get; set; }
    public int Quantity { get; set; }
}