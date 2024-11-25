
using api.DTOs.Category;
using api.Helpers;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("api/categories")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepo;
        public CategoryController(ICategoryRepository categoryRepo)
        {
            _categoryRepo = categoryRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] QueryOject query)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var categories = await _categoryRepo.GetAllAsync(query);

            var categoryDto = categories.Select(c => c.ToCategoryDto());

            return Ok(categoryDto);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var category = await _categoryRepo.GetByIdAsync(id);

            if (category == null)
                return NotFound();

            return Ok(category.ToCategoryDto());
        }

        [HttpPost]
        // [Authorize(Policy = "AdminPolicy")]
        public async Task<IActionResult> Create([FromBody] CategoryCreateDto categoryDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var category = categoryDto.ToCategoryFromCreateDto();

            if (category == null)
                return BadRequest("Not create");

            await _categoryRepo.CreateAsync(category);

            return CreatedAtAction(nameof(GetById), new { id = category.CategoryId }, category.ToCategoryDto());
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] CategoryUpdateDto categoryDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var category = await _categoryRepo.UpdateAsync(id, categoryDto);

            if (category == null)
                return NotFound("Category not found");

            return Ok(category.ToCategoryDto());
        }

    }
}