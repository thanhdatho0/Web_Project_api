using api.DTOs.Subcategory;
using api.Models;

namespace api.Mappers
{
    public static class SubcategoryMappers
    {
        public static SubcategoryDto ToSubcategoryDto(this Subcategory subcategoryModel)
        {
            return new SubcategoryDto
            {
                SubcategoryId = subcategoryModel.SubcategoryId,
                SubcategoryName = subcategoryModel.SubcategoryName,
                Description = subcategoryModel.Description,
                // CategoryId = subcategoryModel.CategoryId,
                // Products = subcategoryModel.Products?.Select(p => p.ToProductDto()).ToList()
            };
        }

        public static Subcategory ToSubcategoryFromCreateDto(this SubcategoryCreateDto subcategoryDto)
        {
            return new Subcategory
            {
                SubcategoryName = subcategoryDto.SubcategoryName,
                Description = subcategoryDto.Description,
                CategoryId = subcategoryDto.CategoryId
            };
        }

        public static Subcategory ToSubcategoryFromUpdateDto(this SubcategoryUpdateDto subcategoryDto)
        {
            return new Subcategory
            {
                SubcategoryName = subcategoryDto.SubcategoryName,
                Description = subcategoryDto.Description
            };
        }
    }
}