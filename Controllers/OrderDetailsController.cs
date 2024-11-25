
using api.Interfaces;
using Microsoft.AspNetCore.Mvc;
using api.Mappers;

namespace api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrderDetailsController : ControllerBase
{
    private readonly IOrderDetailRepository _orderDetailRepository;

    public OrderDetailsController(IOrderDetailRepository orderDetailRepository)
    {
        _orderDetailRepository = orderDetailRepository;
    }

    [HttpGet]
    public async Task<ActionResult> GetAll()
    {
        if(!ModelState.IsValid) return BadRequest(ModelState);
        var orderDetails = await _orderDetailRepository.GetAllAsync();
        return Ok(orderDetails.Select(x => x.ToOrderDetailDto()));        
    }
}