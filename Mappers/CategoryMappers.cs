using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs.Category;
using api.Models;

namespace api.Mappers
{
    public static class CategoryMappers
    {
        public static CategoryDto ToCategoryDto(this Category categoryModel)
        {
            return new CategoryDto
            {
                CategoryId = categoryModel.CategoryId,
                Name = categoryModel.Name,
                Subcategories = categoryModel.Subcategories?.Select(s => s.ToSubcategoryDto()).ToList()
            };
        }

        public static Category ToCategoryFromCreateDto(this CategoryCreateDto categoryDto)
        {
            return new Category
            {
                Name = categoryDto.Name,
            };
        }

        public static Category ToCategoryFromUpdateDto(this CategoryUpdateDto categoryDto)
        {
            return new Category
            {
                Name = categoryDto.Name,
            };
        }

    }
}