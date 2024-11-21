using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models
{
        [Table("Products")]
        public class Product
        {
                //Properties
                [Key]
                [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
                public int ProductId { get; set; }
                public string Name { get; set; } = string.Empty;
                [Column(TypeName = "decimal(18,2)")]
                public decimal Price { get; set; }
                public string? Description { get; set; }
                [Column(TypeName = "decimal(18,2)")]
                public decimal Cost { get; set; }
                public int Stock { get; set; }
                public bool isDeleted { get; set; }
                public List<Image>? Images { get; set; } = new List<Image>();
                public List<ProductColor>? ProductColors { get; set; } = new List<ProductColor>();
                public List<ProductSize>? ProductSizes { get; set; } = new List<ProductSize>();
                public List<ProductMaterial>? ProductMaterials { get; set; } = new List<ProductMaterial>();
                public List<OrderDetail>? OrderDetails { get; set; }
                public int ProviderId { get; set; }
                public Provider? Provider { get; set; }
                public int CategoryId { get; set; }
                public Category? Category { get; set; }
        }
}