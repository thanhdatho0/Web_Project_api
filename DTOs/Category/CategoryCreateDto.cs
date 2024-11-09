using System.ComponentModel.DataAnnotations;

namespace api.DTOs.Category
{
    public class CategoryCreateDto
    {
        [Required(ErrorMessage = "Name is required.")]
        [MinLength(5, ErrorMessage = "Name must be 5 characters")]
        [MaxLength(100, ErrorMessage = "Name cannot be over 100 chacracters")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Description is required.")]
        [MinLength(10, ErrorMessage = "Description must be 10 characters")]
        [MaxLength(280, ErrorMessage = "Description cannot be over 280 chacracters")]
        public string Description { get; set; } = string.Empty;
    }
}