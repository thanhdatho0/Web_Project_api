
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models
{
    public class Size
    {
        //Properties
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SizeId { get; set; }
        public string? SizeValue { get; set; }
        public List<Product>? Products { get; set; }
        public List<ProductSize>? Product_Sizes { get; set; }
    }
}