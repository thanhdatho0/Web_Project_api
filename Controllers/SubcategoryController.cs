using api.DTOs.Subcategory;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;
using api.Helpers;

namespace api.Controllers
{
    [Route("api/subcategories")]
    [ApiController]
    public class SubcategoryController(ISubcategoryRepository subcategoryRepo, ICategoryRepository categoryRepo)
        : ControllerBase
    {
        [HttpGet]
        // [Authorize]
        public async Task<IActionResult> GetAll([FromQuery] QueryOject query)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var subcategories = await subcategoryRepo.GetAllAsync(query);

            var subcategoryDto = subcategories.Select(s => s.ToSubcategoryDto());

            return Ok(subcategoryDto);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var subcategory = await subcategoryRepo.GetByIdAsync(id);

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

            // Chạy các kiểm tra song song
            var categoryExistsTask = categoryRepo.CategoryExists(subcategoryDto.CategoryId);
            var subcategoryNameExistsTask = subcategoryRepo.SubcategoryName(subcategoryDto.SubcategoryName);

            await Task.WhenAll(categoryExistsTask, subcategoryNameExistsTask);

            if (!categoryExistsTask.Result)
                return BadRequest("Category does not exist!");

            if (subcategoryNameExistsTask.Result)
                return BadRequest("Subcategory name has already been taken!");

            var subcategory = subcategoryDto.ToSubcategoryFromCreateDto();

            await subcategoryRepo.CreateAsync(subcategory);

            return CreatedAtAction(nameof(GetById), new { id = subcategory.SubcategoryId }, subcategory.ToSubcategoryDto());
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] SubcategoryUpdateDto subcategoryDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var subcategory = await subcategoryRepo.UpdateAsync(id, subcategoryDto);

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
        //         return NotFound("Subcategory does not exist");

        //     return NoContent();
        // }

    }
}