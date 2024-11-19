using System.ComponentModel.DataAnnotations;

namespace api.DTOs.ProductSize
{
    public class ProductSizeCreateDto
    {
        [Required(ErrorMessage = "SizeId is required.")]
        public int SizeId { get; set; }

        [Required(ErrorMessage = "ProductId is required.")]
        public int ProductId { get; set; }
    }
}