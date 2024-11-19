using System.ComponentModel.DataAnnotations;
using api.Models;

namespace api.DTOs.ProductColor
{
    public class ProductColorCreateDto
    {
        [Required(ErrorMessage = "ColorId is required.")]
        public int ColorId { get; set; }

        [Required(ErrorMessage = "ProductId is required.")]
        public int ProductId { get; set; }
    }
}