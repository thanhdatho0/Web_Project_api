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
                [Column(TypeName = "varchar(100)")]
                public string Name { get; set; } = string.Empty;
                [Column(TypeName = "decimal(18,2)")]
                public decimal Price { get; set; }
                [Column(TypeName = "varchar(200)")]
                public string? Description { get; set; }
                [Column(TypeName = "decimal(18,2)")]
                public decimal Cost { get; set; } //giá nhập kho
                public int  Quantity { get; set; } // Số hàng nhập
                [Column(TypeName = "varchar(50)")]
                public string Unit { get; set; } = string.Empty; // Đơn vị
                public int InStock { get; set; } //Số lượng hàng tồn kho
                public decimal DiscountPercentage { get; set; }
                public bool IsDeleted { get; set; }
                [Column(TypeName = "timestamp")]
                public DateTime CreatedAt { get; set; }
                [Column(TypeName = "timestamp")]
                public DateTime UpdatedAt { get; set; }
                public List<Image> Images { get; set; } = [];
                public List<Inventory> Inventories { get; set; } = [];
                public int ProviderId { get; set; }
                public Provider? Provider { get; set; }
                public int SubcategoryId { get; set; }
                public Subcategory? Subcategory { get; set; }
        }
}