using System.ComponentModel.DataAnnotations;

namespace api.DTOs.PImage
{
    public class ImageCreateDto
    {

        [Required(ErrorMessage = "Alt is required.")]
        [StringLength(100, ErrorMessage = "Alt text cannot exceed 100 characters.")]
        public string Alt { get; set; } = string.Empty;

        [Required(ErrorMessage = "ProductId is required.")]
        public int ProductId { get; set; }

        [Required(ErrorMessage = "ColorId is required.")]
        public int ColorId { get; set; }
    }
}