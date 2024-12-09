
using api.DTOs.Order;
using api.Interfaces;
using api.Mappers;
using api.Models;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrderController(IOrderRepository orderRepository, 
    IOrderDetailRepository orderDetailRepository, IInventoryRepository inventoryRepository)
    : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        if(!ModelState.IsValid) return BadRequest(ModelState);
        var order = await orderRepository.GetAllAsync();
        return Ok(order.Select(o => o.ToOrderDto()));
    }

    [HttpPost]
    public async Task<IActionResult> Create(OrderCreateDto orderCreateDto)
    {
        if(!ModelState.IsValid) return BadRequest(ModelState);
        var order = orderCreateDto.ToOrderCreateDto();
        order.CustomerId ??= null;
        await orderRepository.CreateAsync(order);
        foreach (var orderDetailDto in orderCreateDto.OrderDetails!)
        {
            var orderDetail = orderDetailDto.ToOrderDetailCreateDto();
            orderDetail.OrderId = order.OrderId;
            orderDetail.InventoryId = inventoryRepository
                .GetByDetailsId(orderDetailDto.ProductId, orderDetailDto.ColorId, orderDetailDto.SizeId)
                .Result!
                .InventoryId;
            await orderDetailRepository.CreateAsync(orderDetail);
        }
        return Ok(orderCreateDto);
    }
}