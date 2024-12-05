
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
            SubcategoryName = productModel.Subcategory!.SubcategoryName,
            Description = productModel.Description,
            Cost = productModel.Cost,
            Price = productModel.Price,
            DiscountPercentage = productModel.DiscountPercentage,
            InStock = productModel.InStock,
            IsDeleted = productModel.IsDeleted,
            CreatedAt = productModel.CreatedAt,
            UpdatedAt = productModel.UpdatedAt,
            SubcategoryId = productModel.SubcategoryId,
            ProviderId = productModel.ProviderId,
            
            Sizes = productModel.Inventories.Where(pz => pz.ProductId == productModel.ProductId)
            .Select(pz => new SizeDto
            {
                SizeId = pz.SizeId,
                SizeValue = pz.Size!.SizeValue,
            }).ToHashSet(),
            

            Colors = productModel.Inventories.Where(pc => pc.ProductId == productModel.ProductId)
            .Select(pc => new ColorDto
            {
                ColorId = pc.ColorId,
                Name = pc.Color!.Name,
                HexaCode = pc.Color.HexaCode,
                Images = pc.Color.Images?.Where(i => i.ProductId == productModel.ProductId)
                .Select(i => i.ToImageDto()).ToList()
            }).ToHashSet()
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
            Unit = productDto.Unit!,
            SubcategoryId = productDto.SubcategoryId,
            ProviderId = productDto.ProviderId
        };
    }

    public static void ToProductFromUpdateDto(this Product product, ProductUpdateDto productDto)
    {
        product.Name = productDto.Name;
        product.Description = productDto.Description;
        product.Cost = productDto.Cost;
        product.Price = productDto.Price;
        product.Quantity = productDto.Quantity;
        product.DiscountPercentage = productDto.DiscountPercentage;
        product.UpdatedAt = DateTime.Now;
    }
}