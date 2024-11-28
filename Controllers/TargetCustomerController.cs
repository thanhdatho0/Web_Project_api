
using api.DTOs.TargetCustomer;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("api/targetCustomers")]
    public class TargetCustomerController(ITargetCustomerRepository targetCustomerRepo) : Controller
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var genders = await targetCustomerRepo.GetAllAsync();

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
        public async Task<IActionResult> Create([FromBody] TargetCustomerCreateDto genderDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var gender = genderDto.ToTargetCustomerFromCreateDto();

            await targetCustomerRepo.CreateAsync(gender);

            return CreatedAtAction(nameof(GetById), new { id = gender.TargetCustomerId }, gender.ToTargetCustomerDto());
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] TargetCustomerUpdateDto targetCustomerUpdateDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var targetCustomer = await targetCustomerRepo.UpdateAsync(id, targetCustomerUpdateDto);

            return Ok(targetCustomer?.ToTargetCustomerDto());
        }

    }
}