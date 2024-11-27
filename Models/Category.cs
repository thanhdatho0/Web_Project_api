
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models
{
    public class Category
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CategoryId { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string Name { get; set; } = string.Empty;
        public List<Subcategory>? Subcategories { get; set; } = new List<Subcategory>();
    }
}