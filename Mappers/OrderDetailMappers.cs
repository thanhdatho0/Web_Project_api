using api.DTOs.OrderDetail;
using api.Models;

namespace api.Mappers;

public static class OrderDetailMappers
{
    public static OrderDetailDto ToOrderDetailDto(this OrderDetail orderDetail)
    {
        return new OrderDetailDto
        {
            ProductName = orderDetail.Product?.Name,
            ProductPrice = orderDetail.Product!.Price,
            PriceAfterDiscount = orderDetail.Product!.Price*(1-orderDetail.Product!.DiscountPercentage),
            Size = orderDetail.Size!.SizeValue,
            Color = orderDetail.Color!.Name,
            Quantity = orderDetail.Amount
        };
    }

    public static OrderDetail ToOrderDetailCreateDto(this OrderDetailCreateDto orderDetailCreateDto)
    {
        return new OrderDetail
        {
            ProductId = orderDetailCreateDto.ProductId,
            ColorId = orderDetailCreateDto.ColorId,
            SizeId = orderDetailCreateDto.SizeId,
            Amount = orderDetailCreateDto.Quantity
        };
    }
}