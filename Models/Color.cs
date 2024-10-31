
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models
{
    public class Color
    {
        [Key]
        //Properties
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ColorId { get; set; }
        [Required]
        public string HexaCode { get; set; } = string.Empty;
        [Required]
        public string Name { get; set; } = string.Empty;
        public List<Product>? Products { get; set; }
        public List<ProductColor>? Product_Colors { get; set; }
    }
}