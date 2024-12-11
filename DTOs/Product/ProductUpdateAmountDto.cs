using System.ComponentModel.DataAnnotations;

namespace api.DTOs.Product
{
    public class ProductUpdateAmountDto
    {
        [Range(1, int.MaxValue, ErrorMessage = "Price must be a positive number.")]
        public int Quantity { get; set; }

        [Required(ErrorMessage = "InStock is required.")]
        public int InStock { get; set; }
    }
}