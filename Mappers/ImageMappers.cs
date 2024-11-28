using api.DTOs.PImage;
using api.Models;

namespace api.Mappers
{
    public static class ImageMappers
    {
        public static ImageDto ToImageDto(this Image imageModel)
        {
            return new ImageDto
            {
                ImageId = imageModel.ImageId,
                Url = imageModel.Url,
                Alt = imageModel.Alt,
                ProductId = imageModel.ProductId,
                ColorId = imageModel.ColorId

            };
        }

        public static Image ToImageFromCreateDto(this ImageCreateDto imageDto)
        {
            return new Image
            {
                Url = imageDto.Url,
                Alt = imageDto.Alt,
                ProductId = imageDto.ProductId,
                ColorId = imageDto.ColorId
            };
        }

        public static Image ToProductFromUpdateDto(this ImageUpdateDto imageDto)
        {
            return new Image
            {
                Url = imageDto.Url,
                Alt = imageDto.Alt,
            };
        }
    }
}