
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models
{
    public class Material
    {
        //Properties
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaterialId { get; set; }
        [Required]
        public string MaterialType { get; set; } = string.Empty;
        public List<Product>? Products { get; set; }
        public List<ProductMaterial>? Product_Materials { get; set; }
    }
}