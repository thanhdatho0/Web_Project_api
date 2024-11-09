
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models
{
        public class Product
        {
                //Properties

                [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
                public int ProductId { get; set; }
                [Required]
                public string Name { get; set; } = string.Empty;
                [Required]
                [Column(TypeName = "decimal(18,2)")]
                [Range(0, double.MaxValue)]
                public decimal Price { get; set; }
                public string? Description { get; set; }
                [Required]
                [Column(TypeName = "decimal(18,2)")]
                [Range(0, double.MaxValue)]
                public decimal Cost { get; set; }
                [Required]
                [Range(0, int.MaxValue)]
                public int Stock { get; set; }
                public bool isDeleted { get; set; }
                public List<Image> Images { get; set; }
                public List<Color> Colors { get; set; }
                public List<ProductColor> ColorsOfProduct { get; set; }
                public List<Size>? Sizes { get; set; }
                public List<ProductSize>? ProductSizes { get; set; }
                public List<Material>? Materials { get; set; }
                public List<ProductMaterial>? ProductMaterials { get; set; }
                public List<Order>? Orders { get; set; }
                public List<OrderDetail>? OrderDetails { get; set; }
                public int ProviderId { get; set; }
                public Provider? Provider { get; set; }
                public int CategoryId { get; set; }
                public Category? Category { get; set; }
        }
}