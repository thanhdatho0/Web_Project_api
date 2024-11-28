
using api.DTOs.PColor;
using api.Models;

namespace api.Mappers
{
    public static class ColorMappers
    {
        public static ColorDto ToColorDto(this Color colorModel)
        {
            return new ColorDto
            {
                ColorId = colorModel.ColorId,
                HexaCode = colorModel.HexaCode,
                Name = colorModel.Name,
                Images = colorModel.Images?.Select(i => i.ToImageDto()).ToList()
            };
        }
        public static Color ToColorFromCreateDto(this ColorCreateDto colorCreateDto)
        {
            return new Color
            {
                HexaCode = colorCreateDto.HexaCode,
                Name = colorCreateDto.Name
            };
        }
        public static Color ToColorFromUpdateDto(this ColorUpdateDto colorUpdateDto)
        {
            return new Color
            {
                HexaCode = colorUpdateDto.HexaCode,
                Name = colorUpdateDto.Name
            };

        }

        
    }
}