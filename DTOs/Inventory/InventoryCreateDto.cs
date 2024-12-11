using System.ComponentModel.DataAnnotations;

namespace api.DTOs.Inventory;

public class InventoryCreateDto
{
    [Required(ErrorMessage = "ProductId is required.")]
    public int ProductId { get; set; }

    [Required(ErrorMessage = "ColorId is required.")]
    public int ColorId { get; set; }

    [Required(ErrorMessage = "SizeId is required.")]
    public int SizeId { get; set; }

    [Required(ErrorMessage = "Quantity is required.")]
    [Range(1, int.MaxValue, ErrorMessage = "Quantity must be a positive value.")]
    public int Quantity { get; set; }
}