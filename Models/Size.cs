
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models
{
    public class Size
    {
        //Properties
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SizeId { get; set; }
        [Required]
        public string SizeValue { get; set; } = string.Empty;
        public List<Product>? Products { get; set; }
        public List<ProductSize>? Product_Sizes { get; set; }
    }
}