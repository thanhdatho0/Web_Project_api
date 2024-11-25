using api.DTOs.Order;
using api.DTOs.OrderDetail;
using api.Models;

namespace api.Mappers;

public static class OrderMappers
{
    public static OrderDto ToOrderDto(this Order order)
    {
        return new OrderDto
        {
            OrderId = order.OrderId,
            EmployeeName = order.Employee!.FullName,
            OrderExportDateTime = order.OrderExportDateTime,
            OrderNotice = order.OrderNotice,
            OrderDetails = order.OrderDetails!
                .Select(od => od.ToOrderDetailDto()).ToList(),
            
            TotalAmount = order.OrderDetails!
                .Select(o => o.Amount)
                .Sum(),
            
            Total = order.OrderDetails!
                .Select(o => o.Amount * o.Product!.Price)
                .Sum(),
        };
    }

    public static Order ToOrderCreateDto(this OrderCreateDto orderCreateDto)
    {
        return new Order
        {
            EmployeeId = orderCreateDto.EmployeeId,
            CustomerId = orderCreateDto.CustomerId,
            OrderNotice = orderCreateDto.OrderNotice,
        };
    }
}