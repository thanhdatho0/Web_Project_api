using api.DTOs.Customer;
using api.Interfaces;
using api.Mappers;
using api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CustomerController(ICustomerRepository customerRepo, ITokenService tokenService, UserManager<AppUser> userManager) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult> GetAll()
    {
        var customers = await customerRepo.GetAllAsync();
        return Ok(customers.Select(c => c.ToCustomerDto()));
    }

    [HttpGet]
    [Route("details")]
    [Authorize]
    public async Task<ActionResult> GetCustomerData()
    {
        var accessToken = HttpContext.Request.Headers.Authorization.ToString().Replace("Bearer ", "");
        var principal = tokenService.GetPrincipalFromExpiredToken(accessToken);
        var user = await userManager.FindByNameAsync(principal.Identity!.Name!);
        if(user == null) return Unauthorized();
        var customer = await customerRepo.GetByCodeAsync(user.Id);
        if (customer == null) return NotFound();
        return Ok(customer.ToCustomerDto());
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult> GetById(int id)
    {
        var customer = await customerRepo.GetByIdAsync(id);
        return customer == null ? NotFound() : Ok(customer.ToCustomerDto());
    }
    
    [HttpPut]
    [Route("{id:int}")]
    [Authorize(Roles = "Customer")]
    public async Task<ActionResult> Update([FromRoute] int id, IFormFile? file, [FromForm] CustomerUpdateDto customerUpdateDto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        var baseUrl = $"{Request.Scheme}://{Request.Host}";
        var customer = await customerRepo.UpdateAsync(id, baseUrl, file, customerUpdateDto);
        return customer != null ? Ok(customer.ToCustomerDto()) : NotFound();
    }
}