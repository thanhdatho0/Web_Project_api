using api.DTOs.Customer;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CustomerController(ICustomerRepository customerRepository) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult> GetAll()
    {
        var customers = await customerRepository.GetAllAsync();
        return Ok(customers.Select(c => c.ToCustomerDto()));
    }

    [HttpPut]
    [Route("{id}")]
    public async Task<ActionResult> Update([FromRoute] int id,[FromBody] CustomerUpdateDto customerUpdateDto)
    {
        if(!ModelState.IsValid) return BadRequest(ModelState);
        
        var customer = await customerRepository.UpdateAsync(id, customerUpdateDto);
        return customer != null ? Ok(customer.ToCustomerDto()) : NotFound();
    }
}