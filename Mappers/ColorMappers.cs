using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
                Name = colorModel.Name
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