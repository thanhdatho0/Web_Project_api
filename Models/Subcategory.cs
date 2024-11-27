using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models
{
    [Table("Subcategories")]
    public class Subcategory
    {
        [Key]
        //Properties
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SubcategoryId { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string SubcategoryName { get; set; } = string.Empty;
        [Column(TypeName = "varchar(100)")]
        public string? Description { get; set; }
        public List<Product>? Products { get; set; } = new List<Product>();
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
    }
}