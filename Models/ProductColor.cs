using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models
{
    [Table("ProductColors")]
    public class ProductColor
    {
        public int ProductId { get; set; }
        public Product? Product { get; set; }
        public int ColorId { get; set; }
        public Color? Color { get; set; }
    }

}
