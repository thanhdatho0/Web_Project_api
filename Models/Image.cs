
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models
{
    public class Image
    {
        //Properties
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ImageId {get; set;}
        public string? Url {get; set;}
        public string? Alt {get; set;}
        public List<Product>? Products { get; set; }
        public List<ProductImage>? Product_Imagescts {get; set;}
    }
}