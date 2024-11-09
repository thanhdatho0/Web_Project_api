using System.ComponentModel.DataAnnotations;

namespace api.DTOs.PColor


{
    public class ColorUpdateDto
    {
        [Required(ErrorMessage = "HexaCode is required.")]
        [MinLength(6, ErrorMessage = "HexaCode must be at least 6 characters long.")]
        [RegularExpression(@"^#([A-Fa-f0-9]{6})$", ErrorMessage = "HexaCode must be a valid hexadecimal color code.")]
        public string HexaCode { get; set; } = string.Empty;

        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; } = string.Empty;
    }
}