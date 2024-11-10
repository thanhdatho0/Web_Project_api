using api.DTOs.Product;
using api.Models;

namespace api.Mappers;

public static class ProductMappers
{
    public static ProductDto ToProductDto(this Product productModel)
    {
        return new ProductDto
        {
            ProductId = productModel.ProductId,
            Name = productModel.Name,
            CategoryName = productModel.Category?.Name,
            Description = productModel.Description,
            Cost = productModel.Cost,
            Price = productModel.Price,
            Stock = productModel.Stock,
            CategoryId = productModel.CategoryId,
            ProviderId = productModel.ProviderId,
            Images = productModel.Images?.Select(i => i.ToImageDto()).ToList()
        };
    }

    public static Product ToProductFromCreateDto(this ProductCreateDto productDto, int categoryId, int providerId)
    {
        return new Product
        {
            Name = productDto.Name,
            Description = productDto.Description,
            Cost = productDto.Cost,
            Price = productDto.Price,
            Stock = productDto.Stock,
            CategoryId = categoryId,
            ProviderId = providerId
        };
    }

    public static Product ToProductFromUpdateDto(this ProductUpdateDto productDto)
    {
        return new Product
        {
            Name = productDto.Name,
            Description = productDto.Description,
            Cost = productDto.Cost,
            Price = productDto.Price,
            Stock = productDto.Stock,
        };
    }
}