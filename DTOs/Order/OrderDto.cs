using api.DTOs.OrderDetail;

namespace api.DTOs.Order;

public class OrderDto
{
    public int OrderId { get; set; }
    public string? EmployeeName { get; set; }
    public int CustomerId { get; set; }
    public DateTime OrderExportDateTime { get; set; }
    public string? OrderNotice { get; set; }
    public List<OrderDetailDto> OrderDetails { get; set; } = [];
    public int TotalAmount { get; set; }
    public decimal Total { get; set; }
    public bool Confirmed { get; set; }
}