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
                [Required]
                public string HexaCode { get; set; } = string.Empty;
                [Required]
                public string Name { get; set; } = string.Empty;
                public List<ProductColor>? ProductColors { get; set; } = new List<ProductColor>();
                public List<Image>? Images { get; set; } = new List<Image>();
        }
}