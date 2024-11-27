using api.DTOs.Subcategory;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using api.Helpers;

namespace api.Controllers
{
    [Route("api/subcategories")]
    [ApiController]
    public class SubcategoryController : ControllerBase
    {
        private readonly ISubcategoryRepository _subcategoryRepo;
        private readonly ICategoryRepository _categoryRepo;

        public SubcategoryController(ISubcategoryRepository subcategoryRepo, ICategoryRepository categoryRepo)
        {
            _subcategoryRepo = subcategoryRepo;
            _categoryRepo = categoryRepo;
        }

        [HttpGet]
        // [Authorize]
        public async Task<IActionResult> GetAll([FromQuery] QueryOject query)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var subcategories = await _subcategoryRepo.GetAllAsync(query);

            var subcategoryDto = subcategories.Select(s => s.ToSubcategoryDto());

            return Ok(subcategoryDto);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var subcategory = await _subcategoryRepo.GetByIdAsync(id);

            if (subcategory == null)
                return NotFound();

            return Ok(subcategory.ToSubcategoryDto());
        }

        [HttpPost]
        // [Authorize(Policy = "AdminPolicy")]
        public async Task<IActionResult> Create([FromBody] SubcategoryCreateDto subcategoryDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!await _categoryRepo.CategoryExists(subcategoryDto.CategoryId))
                return BadRequest("Category does not exist!");

            if (await _subcategoryRepo.SubcategoryName(subcategoryDto.SubcategoryName))
                return BadRequest("Subcategory name has already taken!");

            var subcategory = subcategoryDto.ToSubcategoryFromCreateDto();

            if (subcategory == null)
                return BadRequest("Not create");

            await _subcategoryRepo.CreateAsync(subcategory);

            return CreatedAtAction(nameof(GetById), new { id = subcategory.SubcategoryId }, subcategory.ToSubcategoryDto());
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] SubcategoryUpdateDto subcategoryDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var subcategory = await _subcategoryRepo.UpdateAsync(id, subcategoryDto);

            if (subcategory == null)
                return NotFound("Subcategory not found");

            return Ok(subcategory.ToSubcategoryDto());
        }

        // [HttpDelete]
        // [Route("{id:int}")]
        // public async Task<IActionResult> Delete([FromRoute] int id)
        // {
        //     if (!ModelState.IsValid)
        //         return BadRequest(ModelState);

        //     var subcategory = await _subcategoryRepo.DeleteAsync(id);

        //     if (subcategory == null)
        //         return NotFound("Subcategory doese not exists");

        //     return NoContent();
        // }

    }
}