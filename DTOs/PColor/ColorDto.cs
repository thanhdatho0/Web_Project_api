using api.DTOs.PImage;

namespace api.DTOs.PColor;

public class ColorDto
{
    public int ColorId { get; set; }
    public string HexaCode { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public List<ImageDto>? Images { get; set; }
    
    public override bool Equals(object? o)
    {
        if(o is ColorDto colorDto)
            return ColorId == colorDto.ColorId && Name == colorDto.Name;
        return false;
    }
        
    public override int GetHashCode()
    {
        return ColorId.GetHashCode();
    }

}