using api.Interfaces;
using api.Mappers;
using api.Models;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CustomerController : ControllerBase
{
    private readonly ICustomerRepository _customerRepository;

    public CustomerController(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }
    
    [HttpGet]
    public async Task<ActionResult> GetAll()
    {
        var customers = await _customerRepository.GetAllAsync();
        return Ok(customers.Select(c => c.ToCustomerDto()));
    }
}