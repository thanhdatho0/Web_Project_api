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
                public decimal Cost { get; set; } //giá nhập kho
                public int  Quantity { get; set; } // Số hàng nhập
                public string Unit { get; set; } = string.Empty; // Đơn vị
                public int InStock { get; set; } //Số lượng hàng tồn kho
                public decimal DiscountPercentage { get; set; }
                public bool IsDeleted { get; set; }
                [Column(TypeName = "timestamp")]
                public DateTime CreatedAt { get; set; }
                [Column(TypeName = "timestamp")]
                public DateTime UpdatedAt { get; set; }
                public List<Image>? Images { get; set; } = new List<Image>();
                public List<ProductColor>? ProductColors { get; set; } = new List<ProductColor>();
                public List<ProductSize>? ProductSizes { get; set; } = new List<ProductSize>();
                public List<ProductMaterial>? ProductMaterials { get; set; } = new List<ProductMaterial>();
                public List<OrderDetail>? OrderDetails { get; set; }
                public int ProviderId { get; set; }
                public Provider? Provider { get; set; }
                public int SubcategoryId { get; set; }
                public Subcategory? Subcategory { get; set; }
        }
}