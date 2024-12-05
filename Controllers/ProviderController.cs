using api.DTOs.Providerr;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/providers")]
    [ApiController]
    public class ProviderController(IProviderRepository providerRepo) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var providers = await providerRepo.GetAllAsync();

            var providerDto = providers.Select(s => s.ToProviderDto());

            return Ok(providerDto);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var provider = await providerRepo.GetByIdAsync(id);

            if (provider == null)
                return NotFound();

            return Ok(provider.ToProviderDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ProviderCreateDto providerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            
            if(await providerRepo.ProviderNameExists(providerDto.ProviderCompanyName))
                return BadRequest("Provider already exists");

            var provider = providerDto.ToProviderFromCreateDto();

            await providerRepo.CreateAsync(provider);

            return CreatedAtAction(nameof(GetById), new { id = provider.ProviderId }, provider.ToProviderDto());
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] ProviderUpdateDto providerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var provider = await providerRepo.UpdateAsync(id, providerDto);

            if (provider == null)
                return NotFound("Provider not found");

            return Ok(provider.ToProviderDto());
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var provider = await providerRepo.DeleteAsync(id);

            if (provider == null)
                return NotFound("Provider does not exists");

            return NoContent();
        }


    }
}