using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models
{
    [Table("Materials")]
    public class Material
    {
        //Properties
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaterialId { get; set; }
        public string MaterialType { get; set; } = string.Empty;
        public List<Product>? Products { get; set; }
        public List<ProductMaterial>? ProductMaterials { get; set; }
    }
}