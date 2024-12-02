using api.DTOs.OrderDetail;
using api.Models;

namespace api.Mappers;

public static class OrderDetailMappers
{
    public static OrderDetailDto ToOrderDetailDto(this OrderDetail orderDetail)
    {
        return new OrderDetailDto
        {
            ProductName = orderDetail.Inventory!.Product?.Name,
            ProductPrice = orderDetail.Inventory!.Product!.Price,
            PriceAfterDiscount = orderDetail.Inventory!.Product!.Price*(1-orderDetail.Inventory!.Product!.DiscountPercentage),
            Size = orderDetail.Inventory!.Size!.SizeValue,
            Color = orderDetail.Inventory!.Color!.Name,
            Quantity = orderDetail.Amount
        };
    }

    public static OrderDetail ToOrderDetailCreateDto(this OrderDetailCreateDto orderDetailCreateDto)
    {
        return new OrderDetail
        {
            InventoryId = orderDetailCreateDto.InventoryId,
            Amount = orderDetailCreateDto.Quantity
        };
    }
}