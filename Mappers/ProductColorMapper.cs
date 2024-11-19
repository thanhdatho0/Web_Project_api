using api.DTOs.ProductColor;
using api.Models;

namespace api.Mappers
{
    public static class ProductColorMapper
    {
        public static ProductColorDto ToProductColorDto(this ProductColor productColorModel)
        {
            return new ProductColorDto
            {
                ProductId = productColorModel.ProductId,
                Name = productColorModel.Product.Name,
                Price = productColorModel.Product.Price,
                Cost = productColorModel.Product.Cost,
                ColorId = productColorModel.ColorId
            };
        }

        public static ProductColor ToProductColorFromCreateDto(this ProductColorCreateDto productColorDto)
        {
            return new ProductColor
            {
                ColorId = productColorDto.ColorId,
                ProductId = productColorDto.ProductId,
            };
        }
    }
}