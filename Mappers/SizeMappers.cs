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
                ProductSizes = sizeModel.ProductSizes,

            };
        }

        public static Size ToSizeFromCreateDto(this SizeCreateDto sizeDto)
        {
            return new Size
            {
                SizeValue = sizeDto.SizeValue
            };
        }

        public static Size ToSizeFromUpdateDto(this SizeUpdateDto sizeDto)
        {
            return new Size
            {
                SizeValue = sizeDto.SizeValue
            };
        }
    }
}