
using System.ComponentModel.DataAnnotations;

namespace api.DTOs.Category
{
    public class CategoryCreateDto
    {
        [Required(ErrorMessage = "Name is required.")]
        [MinLength(2, ErrorMessage = "Name must be 2 characters")]
        [MaxLength(20, ErrorMessage = "Name cannot be over 20 chacracters")]
        public string Name { get; set; } = string.Empty;
        public int TargetCustomerId { get; set; }
    }
}