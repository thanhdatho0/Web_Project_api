using System.Runtime.Intrinsics.X86;
using api.DTOs.PColor;
using api.DTOs.Product;
using api.DTOs.Size;
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
            SubcategoryName = productModel.Subcategory?.SubcategoryName,
            Description = productModel.Description,
            Cost = productModel.Cost,
            Price = productModel.Price,
            DiscountPercentage = productModel.DiscountPercentage,
            Stock = productModel.Stock,
            isDeleted = productModel.isDeleted,
            CreatedAt = productModel.CreatedAt,
            UpdatedAt = productModel.UpdatedAt,
            SubcategoryId = productModel.SubcategoryId,
            ProviderId = productModel.ProviderId,

            Sizes = productModel.ProductSizes?.Where(pz => pz.ProductId == productModel.ProductId)
            .Select(pz => new SizeDto
            {
                SizeId = pz.SizeId,
                SizeValue = pz.Size.SizeValue,
            }).ToList(),

            Colors = productModel.ProductColors?.Where(pc => pc.ProductId == productModel.ProductId)
            .Select(pc => new ColorDto
            {
                ColorId = pc.ColorId,
                Name = pc.Color.Name,
                HexaCode = pc.Color.HexaCode,
                Images = pc.Color.Images?.Where(i => i.ProductId == productModel.ProductId)
                .Select(i => i.ToImageDto()).ToList()
            }).ToList()

        };
    }
    public static Product ToProductFromCreateDto(this ProductCreateDto productDto)
    {
        return new Product
        {
            Name = productDto.Name,
            Description = productDto.Description,
            Cost = productDto.Cost,
            Price = productDto.Price,
            DiscountPercentage = productDto.DiscountPercentage,
            Stock = productDto.Stock,
            SubcategoryId = productDto.SubcategoryId,
            ProviderId = productDto.ProviderId
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
            DiscountPercentage = productDto.DiscountPercentage,
        };
    }
}