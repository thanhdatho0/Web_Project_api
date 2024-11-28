
using api.Interfaces;
using Microsoft.AspNetCore.Mvc;
using api.Mappers;

namespace api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrderDetailsController(IOrderDetailRepository orderDetailRepository) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult> GetAll()
    {
        if(!ModelState.IsValid) return BadRequest(ModelState);
        var orderDetails = await orderDetailRepository.GetAllAsync();
        return Ok(orderDetails.Select(x => x.ToOrderDetailDto()));        
    }
}