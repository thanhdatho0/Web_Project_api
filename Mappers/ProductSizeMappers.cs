using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs.ProductSize;
using api.Models;

namespace api.Mappers
{
    public static class ProductSizeMappers
    {
        public static ProductSizeDto ToProductSizeDto(this ProductSize productColorModel)
        {
            return new ProductSizeDto
            {
                SizeId = productColorModel.SizeId,
                ProductId = productColorModel.ProductId,
            };
        }
    }
}