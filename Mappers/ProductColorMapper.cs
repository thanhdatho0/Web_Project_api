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
                ColorId = productColorModel.ColorId,
                ProductId = productColorModel.ProductId,
            };
        }
    }
}