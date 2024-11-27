using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models
{
        [Table("Colors")]
        public class Color
        {
                [Key]
                //Properties
                [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
                public int ColorId { get; set; }
                [Column(TypeName = "varchar(10)")]
                public string HexaCode { get; set; } = string.Empty;
                [Column(TypeName = "varchar(50)")]
                public string Name { get; set; } = string.Empty;
                public List<ProductColor>? ProductColors { get; set; } = new List<ProductColor>();
                public List<OrderDetail>? OrderDetails { get; set; } = new List<OrderDetail>();
                public List<Image>? Images { get; set; } = new List<Image>();
        }
}