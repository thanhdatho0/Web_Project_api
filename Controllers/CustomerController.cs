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
}