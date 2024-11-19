using api.DTOs.Providerr;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/providers")]
    [ApiController]
    public class ProviderController : ControllerBase
    {
        private readonly IProviderRepository _providerRepo;

        public ProviderController(IProviderRepository providerRepo)
        {
            _providerRepo = providerRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var providers = await _providerRepo.GetAllAsyns();

            var providerDto = providers.Select(s => s.ToProviderDto());

            return Ok(providerDto);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var provider = await _providerRepo.GetByIdAsync(id);

            if (provider == null)
                return NotFound();

            return Ok(provider.ToProviderDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ProviderCreateDto providerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var provider = providerDto.ToProviderFromCreateDto();

            if (provider == null)
                return BadRequest("Not create");

            await _providerRepo.CreateAsync(provider);

            return CreatedAtAction(nameof(GetById), new { id = provider.ProviderId }, provider.ToProviderDto());
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] ProviderUpdateDto providerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var provider = await _providerRepo.UpdateAsync(id, providerDto);

            if (provider == null)
                return NotFound("Provider not found");

            return Ok(provider?.ToProviderDto());
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var provider = await _providerRepo.DeleteAsync(id);

            if (provider == null)
                return NotFound("Provider does not exists");

            return NoContent();
        }


    }
}