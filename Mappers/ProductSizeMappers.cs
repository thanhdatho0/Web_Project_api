using api.DTOs.ProductSize;
using api.Models;

namespace api.Mappers
{
    public static class ProductSizeMappers
    {
        public static ProductSizeDto ToProductSizeDto(this ProductSize productSizeModel)
        {
            return new ProductSizeDto
            {
                SizeId = productSizeModel.SizeId,
                ProductId = productSizeModel.ProductId,
            };
        }

        public static ProductSize ToProductSizeFromCreateDto(this ProductSizeCreateDto productSizeDto)
        {
            return new ProductSize
            {
                ProductId = productSizeDto.ProductId,
                SizeId = productSizeDto.SizeId,
            };
        }
    }
}