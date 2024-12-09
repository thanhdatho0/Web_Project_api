using System.ComponentModel.DataAnnotations;
using api.DTOs.Inventory;
using api.DTOs.PColor;

namespace api.DTOs.Product;

public class ProductCreateDto
{
    [Required(ErrorMessage = "Product name is required.")]
    [MinLength(3, ErrorMessage = "Product name must be at least 3 characters long.")]
    public string Name { get; set; } = "";

    [Required(ErrorMessage = "Price is required.")]
    [Range(0.01, double.MaxValue, ErrorMessage = "Price must be a positive value.")]
    public decimal Price { get; set; }

    [MaxLength(500, ErrorMessage = "Description cannot exceed 500 characters.")]
    public string? Description { get; set; }

    [Required(ErrorMessage = "Cost is required.")]
    [Range(0.01, double.MaxValue, ErrorMessage = "Cost must be a positive value.")]
    public decimal Cost { get; set; }

    [Required(ErrorMessage = "DiscountPercentage is required.")]
    [Range(0, 0.9, ErrorMessage = "DiscountPercentage must be a positive value.")]
    public decimal DiscountPercentage { get; set; }
    public string? Unit { get; set; }

    [Required(ErrorMessage = "SubcategoryId is required.")]
    public int SubcategoryId { get; set; }
    [Required(ErrorMessage = "ProviderId is required.")]
    public int ProviderId { get; set; }
    public List<ProductInventoryCreateDto> Inventory { get; set; } = [];
}