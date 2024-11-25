using api.DTOs.PImage;

namespace api.DTOs.PColor;

public class ColorToProductDto
{
    public int ColorId { get; set; }
    public List<ImageCreateDto>? Images { get; set; }
}