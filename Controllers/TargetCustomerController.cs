
using api.DTOs.TargetCustomer;
using api.Helpers;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("api/targetCustomers")]
    public class TargetCustomerController(ITargetCustomerRepository targetCustomerRepo) : Controller
    {
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] TargetCustomerQuery query)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var genders = await targetCustomerRepo.GetAllAsync(query);

            var genderDto = genders.Select(g => g.ToTargetCustomerDto());

            return Ok(genderDto);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var gender = await targetCustomerRepo.GetByIdAsync(id);

            if (gender == null)
                return NotFound();

            return Ok(gender.ToTargetCustomerDto());
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create([FromBody] TargetCustomerCreateDto genderDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (await targetCustomerRepo.TargetCustomerNameExists(genderDto.TargetCustomerName))
                return BadRequest("Target customer name already exists");

            var gender = genderDto.ToTargetCustomerFromCreateDto();
            await targetCustomerRepo.CreateAsync(gender);

            return CreatedAtAction(nameof(GetById), new { id = gender.TargetCustomerId }, gender.ToTargetCustomerDto());
        }

        [HttpPut]
        [Route("{id:int}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] TargetCustomerUpdateDto targetCustomerUpdateDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var targetCustomer = await targetCustomerRepo.UpdateAsync(id, targetCustomerUpdateDto);

            return Ok(targetCustomer?.ToTargetCustomerDto());
        }

    }
}