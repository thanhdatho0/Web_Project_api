using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models
{
    [Table("Sizes")]
    public class Size
    {
        //Properties
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SizeId { get; set; }
        [Required]
        public string SizeValue { get; set; } = string.Empty;
        public List<Product>? Products { get; set; } = new List<Product>();
        public List<ProductSize>? ProductSizes { get; set; } = new List<ProductSize>();
    }
}