using api.DTOs.Size;
using api.Models;

namespace api.Mappers
{
    public static class SizeMappers
    {
        public static SizeDto ToSizeDto(this Size sizeModel)
        {
            return new SizeDto
            {
                SizeId = sizeModel.SizeId,
                SizeValue = sizeModel.SizeValue,
            };
        }

        public static Size ToSizeFromCreateDto(this SizeCreateDto sizeDto)
        {
            return new Size
            {
                SizeValue = sizeDto.SizeValue
            };
        }

        public static void ToSizeFromUpdateDto(this Size size, SizeUpdateDto sizeDto)
        {
            size.SizeValue = sizeDto.SizeValue;
        }
    }
}