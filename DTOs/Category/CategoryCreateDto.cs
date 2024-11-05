using System.ComponentModel.DataAnnotations;

namespace api.DTOs.Category
{
    public class CategoryCreateDto
    {
        [Required]
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
    }
}