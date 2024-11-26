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
        public string SizeValue { get; set; } = string.Empty;
        public List<ProductSize>? ProductSizes { get; set; } = new List<ProductSize>();
        public List<OrderDetail>? OrderDetails { get; set; } = new List<OrderDetail>();
    }
}