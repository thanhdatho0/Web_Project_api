using System.ComponentModel;
using api.DTOs.OrderDetail;

namespace api.DTOs.Order;

public class OrderCreateDto
{
    public int EmployeeId { get; set; }
    public int? CustomerId { get; set; }
    public string? OrderNotice { get; set; }
    public List<OrderDetailCreateDto>? OrderDetails { get; set; }
}