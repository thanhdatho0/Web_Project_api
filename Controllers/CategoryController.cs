
using api.DTOs.Category;
using api.Helpers;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("api/categories")]
    public class CategoryController(ICategoryRepository categoryRepo, ITargetCustomerRepository targetCustomerRepo)
        : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] QueryOject query)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var categories = await categoryRepo.GetAllAsync(query);
            return Ok(categories?.Select(c => c.ToCategoryDto()) ?? []);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var category = await categoryRepo.GetByIdAsync(id);
            return category != null ? Ok(category.ToCategoryDto()) : NotFound();
        }

        [HttpPost]
        // [Authorize(Policy = "AdminPolicy")]
        public async Task<IActionResult> Create([FromBody] CategoryCreateDto categoryDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var targetCusterExists = targetCustomerRepo.TargetCustomerExists(categoryDto.TargetCustomerId);
            var categoryNameExists = categoryRepo.CategoryNameExists(categoryDto.Name);
            
            await Task.WhenAll(targetCusterExists, categoryNameExists);
            
            if (!targetCusterExists.Result)
                return BadRequest("TargetCustomer does not exist!");
            if(categoryNameExists.Result)
                return BadRequest("Category name has been taken!");
            
            var category = categoryDto.ToCategoryFromCreateDto();
            try
            {
                await categoryRepo.CreateAsync(category);
                return CreatedAtAction(nameof(GetById), new { id = category.CategoryId }, category.ToCategoryDto());
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] CategoryUpdateDto categoryDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var category = await categoryRepo.UpdateAsync(id, categoryDto);
            return category != null ? Ok(category.ToCategoryDto()) : NotFound("Category not found");
        }

    }
}