
using api.DTOs.TargetCustomer;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("api/tagerCustomers")]
    public class TargetCustomerController : Controller
    {
        private readonly ITargetCustomerRepository _tagerCustomerRepo;

        public TargetCustomerController(ITargetCustomerRepository tagerCustomerRepo)
        {
            _tagerCustomerRepo = tagerCustomerRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetALL()
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var genders = await _tagerCustomerRepo.GetAllAsync();

            var genderDto = genders.Select(g => g.ToTargetCustomerDto());

            return Ok(genderDto);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var gender = await _tagerCustomerRepo.GetByIdAsync(id);

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

            if (gender == null)
                return BadRequest("Not create");

            await _tagerCustomerRepo.CreateAsync(gender);

            return CreatedAtAction(nameof(GetById), new { id = gender.TargetCustomerId }, gender.ToTargetCustomerDto());
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] TargetCustomerUpdateDto genderrDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var gender = await _tagerCustomerRepo.UpdateAsync(id, genderrDto);

            if (gender == null)
                return NotFound("TargetCustomer not found");

            return Ok(gender?.ToTargetCustomerDto());
        }

    }
}